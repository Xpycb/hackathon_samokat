var url_to_getpointsParking = "https://localhost:7282/api/ParkingZones"
var url_Bron = "https://localhost:7282/api/ParkingZones/5"
var myMarc
var myMap
let pointsParking
class pointParking{
    constructor(Id, coordinates, valueFreePlace){
        this.Id = Id
        this.coordinates = coordinates
        this.valueFreePlace = valueFreePlace
    }
}

function start(){
    ymaps.ready(init);
}
async function init(){
    // Создание карты.
    myMap = new ymaps.Map("map", {
        // Координаты центра карты.
        // Порядок по умолчанию: «широта, долгота».
        // Чтобы не определять координаты центра карты вручную,
        // воспользуйтесь инструментом Определение координат.
        center: [56.4700, 84.9800],
        // Уровень масштабирования. Допустимые значения:
        // от 0 (весь мир) до 19.
        zoom: 10
    });
    get_request(url_to_getpointsParking);
    await get_pointsParking();

    for(let i = 0; i < pointsParking.length; i++){
        let a = Math.floor(Math.random() * 40);
        let t = a > 10;
        myMarc = new ymaps.Placemark(
            [pointsParking[i].x, pointsParking[i].y], {
            balloonContent: add_button("забронировать", pointsParking[i].id),
        }, {
            iconColor: t==1 ? 'red' : 'blue',
            interactive: t==1 ? false : true
        });
        myMap.geoObjects.add(myMarc);
    }
        
    }
    

async function get_request(url) {
    let response = await fetch("/data_parking.json");
    //let response = await fetch(url);
    console.log(response);
    if (!response.ok) {
      alert("Error");
    }
    return await response.text();
}
async function get_pointsParking(){
    const strPointParking = await get_request(url_to_getpointsParking);
    pointsParking = JSON.parse(strPointParking)
    console.log(strPointParking);
}
function add_button(text, Id){
    console.log(Id);
    return '<button onclick="addBron('+Id+', this)">забронировать</button>'
}
function addBron(Id, obj){
    console.log(obj);
    alert("Забронировано");
    //obj.id.style

    const temp = get_request(url_Bron);
}
  






// var myMarc
// function start(){
//     ymaps.ready(init);
// }
// function init(){
//     // Создание карты.
//     var myMap = new ymaps.Map("map", {
//         // Координаты центра карты.
//         // Порядок по умолчанию: «широта, долгота».
//         // Чтобы не определять координаты центра карты вручную,
//         // воспользуйтесь инструментом Определение координат.
//         center: [56.4700, 84.9800],
//         // Уровень масштабирования. Допустимые значения:
//         // от 0 (весь мир) до 19.
//         zoom: 10
//     });
//     var myGeoObject = new ymaps.GeoObject({
//         geometry: {
//             type: "Point", // тип геометрии - точка
//             coordinates: [56.475194, 84.986701], // координаты точки
            
//         }
//     });
//     myMarc = new ymaps.Placemark([56.475194, 84.986701], {
//         balloonContent: add_button("забронировать"),}, {
//         iconColor: 'red'}
//         );
//     myMap.geoObjects.add(myMarc);
// }
// function add_button(text) {
//     return "<div>Статус:</div><button onclick='set_color(this, 1)'>"+text+"</button>"
// }
// function set_color(element, flagOfColor){
//     myMarc.options.set('iconColor', 'green')
// }
// function cl(element)
// {
//     console.log(element.innerHTML)
// }
// function show_message()
// {
//     alert("работает кнопка")
// }