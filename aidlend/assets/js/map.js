$(document).ready(function () {
    'use strict';

    function initialize() {
        $(".google-map").each(function (index) {

            // receiving data
            var latData = $(this).data('lat');
            var latVaues = latData.split(',');
            var lngData = $(this).data('lng');
            var lngVaues = lngData.split(',');
            var mapZoom = $(this).data('zoom')

            //Processing wrapper data attribute to coordinate
            var mapOptions = {
                center: {
                    lat: parseFloat(latVaues[0]),
                    lng: parseFloat(lngVaues[0]),
                },
                zoom: mapZoom,
                scrollwheel: false,
                styles: [
                    {
                        elementType: 'geometry',
                        stylers: [{
                            color: '#ffffff'
                        }]
                    },
                    {
                        elementType: 'labels.text.stroke',
                        stylers: [{
                            color: '#ffffff'
                        }]
                    },
                    {
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#aa7c1b'
                        }]
                    },
                    {
                        featureType: 'administrative.locality',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#45340a'
                        }]
            },
                    {
                        featureType: 'poi',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#eab53f'
                        }]
            },
                    {
                        featureType: 'poi.park',
                        elementType: 'geometry',
                        stylers: [{
                            color: '#fcb20b'
                        }]
            },
                    {
                        featureType: 'poi.park',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#fcb20b'
                        }]
            },
                    {
                        featureType: 'road',
                        elementType: 'geometry',
                        stylers: [{
                            color: '#faedce'
                        }]
            },
                    {
                        featureType: 'road',
                        elementType: 'geometry.stroke',
                        stylers: [{
                            color: '#faedce'
                        }]
            },
                    {
                        featureType: 'road',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#e9b43b'
                        }]
            },
                    {
                        featureType: 'road.highway',
                        elementType: 'geometry',
                        stylers: [{
                            color: '#faedce'
                        }]
            },
                    {
                        featureType: 'road.highway',
                        elementType: 'geometry.stroke',
                        stylers: [{
                            color: '#fcb20b'
                        }]
            },
                    {
                        featureType: 'road.highway',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#584210'
                        }]
            },
                    {
                        featureType: 'transit',
                        elementType: 'geometry',
                        stylers: [{
                            color: '#cf9f30'
                        }]
            },
                    {
                        featureType: 'transit.station',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#584210'
                        }]
            },
                    {
                        featureType: 'water',
                        elementType: 'geometry',
                        stylers: [{
                            color: '#efd285'
                        }]
            },
                    {
                        featureType: 'water',
                        elementType: 'labels.text.fill',
                        stylers: [{
                            color: '#1d1707'
                        }]
            },
                    {
                        featureType: 'water',
                        elementType: 'labels.text.stroke',
                        stylers: [{
                            color: '#d7a732'
                        }]
            }
          ]
            };

            //Initiating map
            var map = new google.maps.Map(this, mapOptions),
                marker,
                i;

            for (i = 0; i < latVaues.length; i++) {
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(latVaues[i], lngVaues[i]),
                    map: map,
                    icon: 'images/icons/map-marker.png'
                });
            }
        });
    }
    initialize();
});
