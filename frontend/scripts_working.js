
document.getElementById(start_date).value = document.write(Date());

async function get_request(url) {
    let response = await fetch(url);
    //let response = await fetch(data.json); console.log(response);
    if (!response.ok) {
      alert("Error"); 
    }
    return await response.text();
}
async function get_pointsWorking(){
    const strPointParking = await get_request(url_to_getpointsWorking);
    pointsParking = JSON.parse(strPointParking)
}
function removeCheckbox() {
  var checkboxes = document.querySelectorAll('input[type=checkbox]:checked');
  for (var i = 0; i < checkboxes.length; i++) {
var checkbox = checkboxes[i];
var label = checkbox.nextElementSibling;

checkbox.parentNode.removeChild(checkbox);
label.parentNode.removeChild(label);
  }
}
 
function takeBron(){
  removeCheckbox();
  alert("Забронировано");
}
function table_click(){
  window.location.reload();
}