//< section >
//    < h2 style = "text-align:center;" > Our Statistics </ h2 >


//         < p > Here you can see our data about which categories and restaurants are most popular: </ p >
//        </ section >
//        < div id = "chartContainer" style = "height: 370px; width: 100%;" ></ div >
//           < script src = "https://canvasjs.com/assets/script/canvasjs.min.js" ></ script >




//                    < script type = "text/javascript" >
//        const map = @Html.Raw(ViewData["Graph"]);

//window.onload = function() {
//    var dataPoints = [];

//    var chart = new CanvasJS.Chart("chartContainer", {
//                theme: "light1", 
//                //move
//                animationEnabled: true, 
//                title:
//    {
//    text: "The most popular Dishes",
//                    fontColor: "black"
//                },
//                data:
//    [
//                    {
//    type: "column",
//                        dataPoints: map
//                    }
//                ]
//            });
//chart.render();

//        }
//</ script >

//@Graph 2@
//< script src = "https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js" ></ script >



// < canvas id = "myChart" ></ canvas >
//  < script >
//            const xValues = @Html.Raw(ViewData["GraphX"]);
//const yValues = @Html.Raw(ViewData["GraphY"]);
//var barColors = [
//    "#b91d47",
//    "#00aba9"
//];

//new Chart("myChart", {

//    type: "doughnut",
//    data: {

//        labels: xValues,
//        datasets: [{
//                        backgroundColor: barColors,
//            data: yValues
//                    }]
//                },
//                options:
//{
//title:
//    {
//    display: true,
//                        text: "Number of orders",
//                        fontSize: 40,
//                        fontColor: "black"
//                    }
//}
//            });
//</ script >


//< h1 style = "text-align:center;" >< br />< br /> Delivery Cities </ h1 >
//      < div id = "myMap" ></ div >
//       < script type = 'text/javascript' src = 'https://www.bing.com/api/maps/mapcontrol?key=AgKM2ujhhQsxdOGDplWe_PcRt59_Y8KhlxcQsY4bWurgt-M8nkXVXWERyEd0z6pf&callback=GetMap' async defer></script>