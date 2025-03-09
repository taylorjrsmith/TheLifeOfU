
function AddElement() {
 var ul = document.getElementById("add-item");
 var li = document.createElement("li");
 var input_value = document.getElementById("name").nodeValue;
 li.appendChild(document.createTextNode(input_value));
 ul.appendChild(li);
}


$(document).ready(function(){
  $('.tooltipped').tooltip();
});

$('.dropdown-trigger').dropdown();

$(document).ready(function(){
  $('select').formSelect();
});