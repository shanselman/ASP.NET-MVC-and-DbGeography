(function() {
  // Find the textbox and cache it for later.
  var $input = $('.editor-for-dbgeography'),
      latitude = $input.data('latitude'),
      longitude = $input.data('longitude');

  // Create the map div and insert it into the page.
  var $map = $('<div>', {
    css: {
      width: '400px',
      height: '400px'
    }
  }).insertAfter($input);

  // Create a "Google(r)(tm)" LatLong object representing our DBGeometry's lat/long.
  var position = new google.maps.LatLng(latitude, longitude);

  var mapOptions = {
    zoom: 14,
    center: position,
    mapTypeId: google.maps.MapTypeId.ROADMAP,
    maxZoom: 14
  };

  // Initialize the map widget.
  var map = new google.maps.Map($map[0], mapOptions);

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

  google.maps.event.addListener(map, 'click', updateMarker);

  // Attempt to react to user edits in the input field.
  $input.on('change', function(evt) {
    var latLong = this.value.match(/-?\d+\.\d+/g);

    latLong = new google.maps.LatLng(latLong[0], latLong[1]);

    updateMarker({ latLng: latLong });
  });
})();