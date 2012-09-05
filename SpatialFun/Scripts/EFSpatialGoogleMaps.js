(function() {
  // Method signature matching $.fn.each()'s, for easy use in the .each loop later.
  var initialize = function(i, el) {
    // el is the input element that we need to initialize a map for, jQuery-ize it,
    //  and cache that since we'll be using it a few times.
    var $input = $(el);

    // Create the map div and insert it into the page.
    var $map = $('<div>', {
      css: {
        width: '400px',
        height: '400px'
      }
    }).insertAfter($input);

    var latLong = parseLatLong(this.value);

    // Create a "Google(r)(tm)" LatLong object representing our DBGeometry's lat/long.
    var position = new google.maps.LatLng(latLong.latitude, latLong.longitude);

    // Initialize the map widget.
    var map = new google.maps.Map($map[0], {
      zoom: 14,
      center: position,
      mapTypeId: google.maps.MapTypeId.ROADMAP,
      maxZoom: 14
    });

    // Place a marker on it, representing the DBGeometry object's position.
    var marker = new google.maps.Marker({
      position: position,
      map: map
    });

    var updateMarker = function(updateEvent) {
      marker.setPosition(updateEvent.latLng);

      map.panTo(updateEvent.latLng);

      // Black magic, courtesy of Hanselman's original version.
      $input.val(marker.getPosition().toUrlValue(13));
    };

    // If the input came from an EditorFor, initialize editing-related events.
    if ($input.hasClass('editor-for-dbgeography')) {
      google.maps.event.addListener(map, 'click', updateMarker);

      // Attempt to react to user edits in the input field.
      $input.on('change', function(evt) {
        var latLong = parseLatLong(this.value);

        latLong = new google.maps.LatLng(latLong.latitude, latLong.longitude);

        updateMarker({ latLng: latLong });
      });
    }
  };

  var parseLatLong = function(value) {
    if (!value)
      return undefined;

    var latLong = value.match(/-?\d+\.\d+/g);

    return {
      latitude: latLong[0],
      longitude: latLong[1]
    };
  };

  // Find the textbox and cache it for later.
  var $inputs = $('.editor-for-dbgeography, .display-for-dbgeography');

  $inputs.each(initialize);
})();