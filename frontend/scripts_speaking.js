document.getElementById(start_date).value = document.write(Date());
var kv_room1 = [1, 0, 0, 0, 1, 1, 1, 1, 1, 1];
var kv_room2 = [1, 0, 0, 0, 1, 0, 1, 0, 1, 1];
var kv_room3 = [1, 1, 1, 1, 1, 1, 0, 0, 1, 1];
var kv_room4 = [1, 1, 1, 1, 1, 1, 1, 1, 1, 1];

function room_click(num){
  document.getElementById("chatWindow").style.display = 'flex';
  <iframe src="https://viarune.rocket.chat/home" class="rocket_chat"></iframe>
  var kv_room;
  if (num === 1) {
    kv_room = kv_room1;
  }
  else if (num === 2) {
    kv_room = kv_room2;
  }
  else if (num === 3) {
    kv_room = kv_room3;
  }
  else if (num === 4) {
    kv_room = kv_room4;
  }
  else{
    kv_room = kv_room4;
  }

  var checkboxes = document.querySelectorAll('input[type=checkbox]');
  for (var i = 0; i < checkboxes.length; i++){
    if(kv_room[i] > 0){
      checkboxes[i].checked = true;
    }
    else{
      checkboxes[i].checked = false;
    }
  }
} 



async function get_request(url) {
    let response = await fetch(url);
    console.log(response);
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
  