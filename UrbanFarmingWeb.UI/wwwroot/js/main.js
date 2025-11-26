(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$(".toggle-password").click(function() {

	  $(this).toggleClass("fa-eye fa-eye-slash");
	  var input = $($(this).attr("toggle"));
	  if (input.attr("type") == "password") {
	    input.attr("type", "text");
	  } else {
	    input.attr("type", "password");
	  }
	});

})(jQuery);


document.getElementById('openPopup').onclick = function () {
    const popupContent = document.querySelector('.popup-content');
    popupContent.classList.add('show');
    document.getElementById('popup').style.display = 'block';
}

document.getElementById('closePopup').onclick = function () {
    const popupContent = document.querySelector('.popup-content');
    popupContent.classList.remove('show');
    setTimeout(() => {
        document.getElementById('popup').style.display = 'none';
    }, 300); // Tempo da animação
}

window.onclick = function (event) {
    if (event.target == document.getElementById('popup')) {
        const popupContent = document.querySelector('.popup-content');
        popupContent.classList.remove('show');
        setTimeout(() => {
            document.getElementById('popup').style.display = 'none';
        }, 300);
    }
}

document.getElementById('registrationForm').onsubmit = function (event) {
    event.preventDefault();
    alert('Cadastro realizado com sucesso!');
    const popupContent = document.querySelector('.popup-content');
    popupContent.classList.remove('show');
    setTimeout(() => {
        document.getElementById('popup').style.display = 'none';
    }, 300);
}
