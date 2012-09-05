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

  google.maps.event.addListener(map, 'click', updateMarker);

  function updateMarker(updateEvent) {
    marker.setPosition(updateEvent.latLng);

    // Black magic, courtesy of Hanselman's original version.
    $input.val(marker.getPosition().toUrlValue(13));
  }
})();