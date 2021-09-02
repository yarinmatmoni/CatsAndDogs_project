

//function GetMap() {
//    map = new Microsoft.Maps.Map('#myMap', {
//        credentials: 'AmL7oLu1IcsqMguBIRNjYrN138xH3FEbqiQEGwIKoq3ti1EaaBU4eSJ6nxgXS0gv',
//        //No need to set credentials if already passed in URL 
//        center: new Microsoft.Maps.Location(31.9700919, 34.77205380048267),
//        mapTypeId: Microsoft.Maps.MapTypeId.road,
//        zoom: 10 
//    });

//    let name;
//    const bing_key = 'AmL7oLu1IcsqMguBIRNjYrN138xH3FEbqiQEGwIKoq3ti1EaaBU4eSJ6nxgXS0gv';
//    var pin;
//    var pin_location;
//    let count = 0;
//    $.ajax({
      
//       // url: 'https://' + new URL(window.location.host) + '/Locations/GetPlacesList',
//        type: 'GET',
//        success: function (data) { // הדאטה קשור ל url משם הוא שואב את הנתונים
//            $.each(data, function (index) {
//                setTimeout(() => {

//                    //name = data[index].name;
                    
//                    name = data[index].credentials;
//                    console.log(name);

//                    pin_location = getLatLon(name, bing_key);

//                    pin = new Microsoft.Maps.Pushpin(pin_location);
//                    map.entities.push(pin);
//                }, index * 200);
//            });
//        },
//        error: function (err) {
//            console.log(err);
//        }
//    });
//}


//function getLatLon(query, bing_key) { // מביא את הקואורדינטות
//    var latlon;
//    var mapObject;
//    $.ajax({
//        method: 'GET',
//        url: `https://dev.virtualearth.net/REST/v1/Locations?q=${query}&key=${bing_key}`,
//        async: false,
//        success: function (data) {
//            latlon = data.resourceSets[0].resources[0].point.coordinates;
//            mapObject = new Microsoft.Maps.Location(latlon[0], latlon[1])
//        },
//        error: function (err) {
//            console.log(err);
//        }
//    });
//    return mapObject;
//}


//    //function getLatLon(queryx, queryy, bing_key) {
//    //    var latlon;
//    //    var mapObject;
//    //    $.ajax({
//    //        method: 'GET',
//    //        url: `https://dev.virtualearth.net/REST/v1/Locations?q=${query}&key=${bing_key}`,
//    //        async: false,
//    //        success: function (data) {
//    //            latlon = data.resourceSets[0].resources[0].point.coordinates;
//    //            mapObject = new Microsoft.Maps.Location(latlon[0], latlon[1])
//    //            //console.log(data);
//    //            //console.log(latlon[0] + ',' + latlon[1]);
//    //            //console.log(mapObject)
//    //            //return mapObject;
//    //        },
//    //        error: function (err) {
//    //            console.log(err);
//    //        }
//    //    });
//    //    return mapObject;
//    //}


