(function () {
    //this loads a module for infobox
    (function($m) {
        /* $m == Microsoft.Maps namespace */
        /* Add "Microsoft.Maps.Ext" namespace if it doesn't exist
        This is used to hold the custom InfoBox functionality */
        if (!$m.Ext) {
            $m.Ext = { };
        }

        /* Microsoft.Maps.Ext.InfoBox extension */
        var InfoBox = $m.Ext.InfoBox = function(title, desc, map) {
            return new InfoBox.fn.init(title, desc, map);
        };
        InfoBox.prototype = InfoBox.fn = {
            init: function(title, desc, map) {
                this._element = null;
                this._title = title;
                this._description = desc;
                this._map = map;
            },
            title: function(v) {
                if (v !== undefined) {
                    this._title = v;
                    return this;
                }
                return this._title;
            },
            description: function(v) {
                if (v !== undefined) {
                    this._description = v;
                    return this;
                }
                return this._description;
            },
            show: function(e) {
                /* Get location of Pushpin */
                var loc = this.map().
                    tryLocationToPixel(
                        e.target.getLocation(), Microsoft.Maps.PixelReference.page
                    );
                if (this._element === null) {
                    /* Create <div> to show as InfoBox */
                    this._element = $('<div>').
                        addClass('infobox').
                        appendTo($(document.body)).
                        html('<h4>' + this.title() + '</h4>' + this.description());
                }
                /* Show InfoBox and set position*/
                this._element.show().css({
                    position: 'absolute',
                    /* offset the infobox a little */
                    top: loc.y - 10,
                    left: loc.x + 10
                });
            },
            hide: function() {
                /* Hide InfoBox from view */
                if (this._element !== null) {
                    this._element.hide();
                }
            },
            map: function(v) {
                if (v) {
                    this._map = v;
                    return this;
                }
                return this._map;
            }
        };
        InfoBox.fn.init.prototype = InfoBox.fn;

        /* Microsoft.Maps.Pushpin extensions */
        (function(proto) {
            if (!proto.setInfoBox) {
                proto.setInfoBox = function(infoBox) {
                    this.removeInfoBox();
                    this.infobox = infoBox;
                    /* attach event handlers */
                    this.infoboxMouseOverHandler = $m.Events.addHandler(
                        this,
                        "mouseover",
                        function(e) {
                            infoBox.show(e);
                        });
                    this.infoboxMouseOutHandler = $m.Events.addHandler(
                        this,
                        "mouseout",
                        function(e) {
                            infoBox.hide(e);
                        });
                };
            }
            if (!proto.removeInfoBox) {
                proto.removeInfoBox = function() {
                    /* detach event handlers */
                    $m.Events.removeHandler(this.infoboxMouseOverHandler);
                    $m.Events.removeHandler(this.infoboxMouseOutHandler);
                    this.infobox = null;
                };
            }
        })($m.Pushpin.prototype);
    })(Microsoft.Maps);


    // Method signature matching $.fn.each()'s, for easy use in the .each loop later.
    var initialize = function(i, el) {
        // el is the input element that we need to initialize a map for, jQuery-ize it,
        //  and cache that since we'll be using it a few times.
        var $input = $(el);

        // Create the map div and insert it into the page.
        var $map = $('<div>', {
            css: {
                width: '100%',
                height: '400px',
                position: 'relative'
            }
        }).insertAfter($input);

        // Attempt to parse the lat/long coordinates out of this input element.
        var latLong = parseLatLong(this.value);
        //The default zoom level
        var defaultZoomlevel = 14;
        //shoud we opt in in using the current location
        var useCurrentLocation = true;

        // If there was a problem attaining a lat/long from the input element's value,
        //  set it to a sensible default that isn't in the middle of the ocean.
        if (!latLong || !latLong.latitude || !latLong.longitude) {
            latLong = {
                latitude: 40.716948,
                longitude: -74.003563
            };
            //maybe it's create, and we can use current location to give him a heads up
            useCurrentLocation = true;
        }

        //Create a "Bing(r)(tm)" LatLong object representing our DBGeometry's lat/long
        var position = new Microsoft.Maps.Location(latLong.latitude, latLong.longitude);
        //Create Pushpin
        var pushpin = new Microsoft.Maps.Pushpin(position);
        var searchManager = null;
        var infoboxOptions = { width: 200, height: 100, showCloseButton: true, zIndex: 0, offset: new Microsoft.Maps.Point(10, 0), showPointer: true, title: 'Is it here?', description: 'its close to..' };
        var defaultInfobox = new Microsoft.Maps.Infobox(position, infoboxOptions);
        defaultInfobox.setOptions({ visible: true });

        var endDragDetails = function(e) {
            position = e.entity.getLocation();
            $input.val(position.latitude.toString() + "," + position.longitude.toString());
            defaultInfobox.setOptions({ visible: true });
            defaultInfobox.setLocation(position);
            if (searchManager == null)
                Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: initSearchManager });
            else
                reverseGeocodeRequest();

        };


        //create the request toReverse our location to something meaningful
        var reverseGeocodeRequest = function () {
            //some user data 
            var userData = { name: 'Maps Test User', id: 'XYZ' };
            //create a request with the current postion
            var request =
                {
                    location: position,
                    callback: onReverseGeocodeSuccess,
                    errorCallback: onReverseGeocodeFailed,
                    userData: userData
                };
            searchManager.reverseGeocode(request);
        };

       var onReverseGeocodeSuccess = function(result, userData) {
            if (result) {

                map.setView({ center: result.location, zoom: defaultZoomlevel });
                //update the info box
                var infoboxOptions = { description: result.name };
                defaultInfobox.setOptions(infoboxOptions);
            } else {
                alert('no Location found, try panning map');
            }
        };

        var onReverseGeocodeFailed = function(result, userData) {
            alert('Rev geocode failed');
        };

        //Initialize the map widget.
        //use your own credentials please
        var map = Microsoft.Maps.loadModule('Microsoft.Maps.Themes.BingTheme', {
            callback: function() {
                map = new Microsoft.Maps.Map($map[0], {
                    credentials: 'AqTvhJT1tKQjRwvP742mqvrE1cyVUlP-0TGW9iiS74d_GDkiEKxFwWC0cGlQnryr',
                    theme: new Microsoft.Maps.Themes.BingTheme(),
                    showBreadcrumb: true,
                    zoom: defaultZoomlevel
                });


                //if we opt in
                if (useCurrentLocation) {
                    //get currentlocation
                    var geoLocationProvider = new Microsoft.Maps.GeoLocationProvider(map);
                    //on sucess update the marker position
                    geoLocationProvider.getCurrentPosition(({ successCallback: function(object) { updateMarker(object.center); } }));
                } else {
                    map.entities.clear();
                    map.entities.push(pushpin);

                }
                map.entities.push(defaultInfobox);

            }
        });
        var initSearchManager = function() {
            map.addComponent('searchManager', new Microsoft.Maps.Search.SearchManager(map));
            searchManager = map.getComponent('searchManager');
            reverseGeocodeRequest();
        };


        var updateMarker = function(updateEvent) {

            position = new Microsoft.Maps.Location(updateEvent.latitude, updateEvent.longitude);
            pushpin.setLocation(position);
            map.entities.push(pushpin);
            //  // This new location might be outside the current viewport, especially
            //  //  if it was manually entered. Pan to center on the new marker location.
            map.setView({ center: position, zoom: defaultZoomlevel });
            $input.val(position.latitude.toString() + "," + position.longitude.toString());

        };

        //// If the input came from an EditorFor, initialize editing-related events.
        if ($input.hasClass('editor-for-dbgeography')) {

            //Make the pushpin draggable
            pushpin.setOptions({ draggable: true });

            //Add the drag event end
            Microsoft.Maps.Events.addHandler(pushpin, 'dragend', endDragDetails);
            //  Attempt to react to user edits in the input field.
            $input.on('change', function() {
                var latLong = parseLatLong(this.value);
                updateMarker(latLong);
            });
        }

    };

    var parseLatLong = function(value) {
        if (!value) {
            return undefined;
        }

        var latLong = value.match(/-?\d+\.\d+/g);

        return {
            latitude: latLong[0],
            longitude: latLong[1]
        };
    };

    // Find all DBGeography inputs and initialize maps for them.
    $('.editor-for-dbgeography, .display-for-dbgeography').each(initialize);
})();


//I was working in something similar with the Bing MAps, so i resolved to try and share my version.

//I used a draggble puspin to help select the right location on the map when adding or editing.

//The bing maps uses the good looking Me-ro theme, and also makes use of the search module, and a infobox module. to Show a infobox with a reverse geocode of the geolocation of the dragged pin.

//Im not a big javascript coder so please feel free to make better sugestions.  