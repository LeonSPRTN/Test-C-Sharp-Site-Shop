// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {

	$(".image").click(function () {
		var img = $(this);
		var alt = img.attr('alt');
		var src = img.attr('src');

		$("body").append("<div class='popup'>" +
			"<div class='popup_bg'></div>" +
			"<img src='" + src + "' class='popup_img'/>" +
			"<p class = 'namepopup'>" +alt+ "</p>"+
			"</div>");

		$(".popup").fadeIn(800);
		$(".popup_bg").click(function () {
			$(".popup").fadeOut(800);
			setTimeout(function () {
				$(".popup").remove();
			}, 800);
		});
	});

});