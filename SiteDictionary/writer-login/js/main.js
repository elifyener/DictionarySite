var pwd = document.getElementById('pwd');
var eye = document.getElementById('eye');

eye.addEventListener('click', togglePass);

function togglePass() {

	eye.classList.toggle('active');

	(pwd.type == 'password') ? pwd.type = 'text' : pwd.type = 'password';
}

$(function () {

    $('.btn-link[aria-expanded="true"]').closest('.accordion-item').addClass('active');
  $('.collapse').on('show.bs.collapse', function () {
	  $(this).closest('.accordion-item').addClass('active');
	});

  $('.collapse').on('hidden.bs.collapse', function () {
	  $(this).closest('.accordion-item').removeClass('active');
	});

    

});