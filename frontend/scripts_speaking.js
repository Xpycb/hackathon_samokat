var url_to_getPointsWorking = "some_url";

function room_click(num) {
  document.getElementById("chatWindow").style.display = 'flex';
  document.getElementById("chatWindow").innerHTML = '<iframe src="https://viarune.rocket.chat/home" class="rocket_chat"></iframe>';
  var kv_room;
  if (num === 1) {
    kv_room = kv_room1;
  } else if (num === 2) {
    kv_room = kv_room2;
  } else if (num === 3) {
    kv_room = kv_room3;
  } else if (num === 4) {
    kv_room = kv_room4;
  } else {
    kv_room = kv_room4;
  }
  var checkboxHTML = "";
  for (var i = 0; i < kv_room.length; i++) {
    if (kv_room[i] > 0) {
      checkboxHTML += '<input type="checkbox" checked>';
    } else {
      checkboxHTML += '<input type="checkbox">';
    }
    checkboxHTML += '<label>Комната ' + (i + 1) + '</label><br>';
  }
  document.getElementById("checkboxes").innerHTML = checkboxHTML;
}

function click(){
  var iframeSrc = "https://viarune.rocket.chat/home";
  document.getElementsByClassName("chatWindow").style.display = 'flex';
  document.getElementsByClassName("chatWindow").innerHTML = '<iframe src="' + iframeSrc + '" class="rocket_chat"></iframe>';
}

window.addEventListener('load', function() {
  var openChatBtn = document.getElementById("openChatBtn");
  openChatBtn.addEventListener("click", click);
});

function removeCheckbox() {
  var checkboxes = document.querySelectorAll('input[type=checkbox]:checked');
  for (var i = 0; i < checkboxes.length; i++) {
    var checkbox = checkboxes[i];
    var label = checkbox.nextElementSibling;
    checkbox.parentNode.removeChild(checkbox);
    label.parentNode.removeChild(label);
  }
}

function takeBron() {
  removeCheckbox();
  alert("Забронировано");
}