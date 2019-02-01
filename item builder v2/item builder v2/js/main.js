// Smooth scrolling effect */
$(document).ready(function () {
  // Add smooth scrolling to all links
  $("a").on('click', function (event) {

    // Make sure this.hash has a value before overriding default behavior
    if (this.hash !== "") {
      // Prevent default anchor click behavior
      event.preventDefault();

      // Store hash
      var hash = this.hash;

      // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
      $('html, body').animate({
        scrollTop: $(hash).offset().top
      }, 800, function () {

        // Add hash (#) to URL when done scrolling (default click behavior)
        window.location.hash = hash;
      });
    } // End if
  });

  $("form").on("change", ".file-upload-field", function () {
    $(this).parent(".file-upload-wrapper").attr("data-text", $(this).val().replace(/.*(\/|\\)/, ''));
  });

  // Changes text depending on option choosen 
  $('.item').click(function () {
    $('.stats-title').html("These will be the stats of your item.");
  });

  $('.booster').click(function () {
    $('.stats-title').html("These will be the stats of your booster.");
  });

  isBooster();
});

function isBooster() {
  /* Change stat options if booster is selected */
  $('.booster').click(function () {
      document.getElementById('itemName-label').innerHTML = 'Health gain';
    
      /* removing inputs that done relate to a booster and replacing with a text box. */
      document.getElementById('itemDamage').style.visibility = 'hidden';
      document.getElementById('itemDamage-label').style.visibility = 'hidden';
      document.getElementById('itemDurability').style.visibility = 'hidden';
      document.getElementById('itemDurability-label').style.visibility = 'hidden';
  

      /* addition of text box */
      var textArea = document.createElement("textarea");
      var inputWrapper = document.createElement("text-input");
      inputWrapper.appendChild(textArea);
  });
  

  

}