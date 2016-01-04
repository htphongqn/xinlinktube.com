// JavaScript Document
 var windowWidth = $(window).width();
 var windowHeight = $(window).height();
 if(windowWidth<=991){
    $(".navx").addClass("w3-sidenav");
  }
// if(windowWidth>991)
//   $(".navx").addClass("");
  if(windowWidth<=991){
$( ".navx > ul > li" ).has( "ul" ).addClass("parent");
$( ".navx > ul > li.parent" ).prepend("<i class='fa fa-plus'></i>");
$(function () {
 	$('.navx > ul > li>i').on('click', function (e) {
		$(this).parent("li").addClass("active-left");
		$(this).parent("li").children("ul").slideToggle();
		
		$(this).parent("li").addClass("yl");
		if(	$(this).parent("li").children("i").hasClass("fa fa-plus")){
		$(this).parent("li").children("i").removeClass("fa-plus").addClass("fa-minus");
		
		}
		else{
		$(this).parent("li").children("i").removeClass("fa-minus").addClass("fa-plus");
		$(this).parent("li").removeClass("yl");
		}
});
});
}
$(window).resize(function() {
  //update stuff
 // if(windowWidth<=991){
//  	$(".navx").addClass("animated fadeInLeft w3-sidenav");
//  }
//  if(windowWidth>991)
//  	$(".navx").addClass("");
});

////Open the Navigation Pane Hiding All of the Content
//function w3_open() {
//    document.getElementsByClassName("w3-sidenav")[0].style.width = "100%";
//    document.getElementsByClassName("w3-sidenav")[0].style.display = "block";
//}
//function w3_close() {
//    document.getElementsByClassName("w3-sidenav")[0].style.display = "none";
//}

////Shift the Content to the Right
//function w3_open() {
//  document.getElementById("main").style.marginLeft = "25%";
//  document.getElementsByClassName("w3-sidenav")[0].style.width = "25%";
//  document.getElementsByClassName("w3-sidenav")[0].style.display = "block";
//  document.getElementsByClassName("w3-opennav")[0].style.display = 'none';
//}
//function w3_close() {
//  document.getElementById("main").style.marginLeft = "0%";
//  document.getElementsByClassName("w3-sidenav")[0].style.display = "none";
//  document.getElementsByClassName("w3-opennav")[0].style.display = "inline-block";
//}

//var windowWidth = $(window).width(); //retrieve current window width
//var windowHeight = $(window).height(); //retrieve current window height
//var documentWidth = $(document).width(); //retrieve current document width
//var documentHeight = $(document).height(); //retrieve current document height
//var vScrollPosition = $(document).scrollTop(); //retrieve the document scroll ToP position
//var hScrollPosition = $(document).scrollLeft(); //retrieve the document scroll Left position

function w3_open() {
    document.getElementsByClassName("w3-sidenav")[0].style.display = "block";
}
function w3_close() {
     document.getElementsByClassName("w3-sidenav")[0].style.display = "none";
}

//popup search
 var notH = 1,
$pop = $('.popupSearch').hover(function () { notH ^= 1; });

  $(document).on('mouseup keyup', function (e) {
	  if (notH || e.which == 27) $pop.stop().hide();
  });
  $('.popupSearch').hide();
$(document).ready(function () {
  $('.trigger').click(function () {
	  $('.popupSearch').slideToggle();  
  });
  $('.btn-close').click(function () {
	  $('.popupSearch').slideUp('fast');
  });
});

 //tg-des 

   
$('.link-video .tdt').hide();
$(document).ready(function () {
  $('.tg-source').click(function () {
			$(".link-video .tg-source").hide();
	  $('.link-video .tdt').slideToggle(); 
			 
  });
   
});


$('.des-video').hide();
$(document).ready(function () {
  $('.tg-des').click(function () {
			//$(".des-video").hide();
	  $('.des-video').slideToggle(); 
			 
  });
   
});
		
		
		

//back top
  (function($){
	$.fn.UItoTop = function(options) {

 		var defaults = {
			text: '',
			min: 500,			
			scrollSpeed: 800,
  			containerID: 'back-top',
  			containerClass: 'fa fa-chevron-up',
			easingType: 'linear'
					
 		};

 		var settings = $.extend(defaults, options);
		var containerIDhash = '#' + settings.containerID;
		var containerHoverIDHash = '#'+settings.containerHoverID;
			
		$('body').append(' <a href="#" id="'+settings.containerID+'" class="'+settings.containerClass+'" >'+settings.text+'</a> ');		
		
		$(containerIDhash).hide().click(function(){			
			$('html, body').stop().animate({scrollTop:0}, settings.scrollSpeed, settings.easingType);
			$('#'+settings.containerHoverID, this).stop().animate({'opacity': 0 }, settings.inDelay, settings.easingType);
			return false;
		})
		
								
		$(window).scroll(function() {
			var sd = $(window).scrollTop();
			if(typeof document.body.style.maxHeight === "undefined") {
				$(containerIDhash).css({
					'position': 'absolute',
					'top': $(window).scrollTop() + $(window).height() - 50
				});
			}
			if ( sd > settings.min ) 
				$(containerIDhash).stop(true,true).fadeIn(600);
			else 
				$(containerIDhash).fadeOut(600);
		});
};
})(jQuery);

 
$( ".navx li h3").addClass("lv lv1");
$( ".navx li h4").addClass("lv lv2");
$( ".navx li h5").addClass("lv lv3");
$( ".breadcrumb li:not(:last-child) " ).prepend("<i class='fa fa-angle-double-right'></i>");
//// Truncate but leave last word
//var h1Title = $('h1').text();
//if (h1Title.length > 15) {
//  var chopWord = h1Title.trim().substring(0, 15).split(" ").slice(0, -1).join(" ") + "…";
//  $('h1').text(chopWord);
//}
//
//// Truncate to specific character
//var h2Title = $('h2').text();
//if (h2Title.length > 15) {
//  var chopCharacter = h2Title.trim().substring(0, 15) + "…";
//  $('h2').text(chopCharacter);
//}
//
//// Truncate all siblings at specific character
//$('ul li').each(function() {
//  var entryTitle = $(this).text().trim();
//  if (entryTitle.length > 20) {
//    var chopCharacter = entryTitle.substring(0, 20) + "…";
//    $(this).text(chopCharacter);
//  }
//});
//
//// Truncate but leave last word
//var myTag = $('#truncate').text();
//if (myTag.length > 100) {
//  var truncated = myTag.trim().substring(0, 100).split(" ").slice(0, -1).join(" ") + "…";
//  $('#truncate').text(truncated);
//}

// Truncate to specific character
//var myTag = $('.video-title a').text();
//if (myTag.length > 15) {
//  var truncated = myTag.trim().substring(0, 60) + "…";
//  $('.video-title a').text(truncated);
//}

//var myTag = $('.side .video-title a').text();
//if (myTag.length > 15) {
//  var truncated = myTag.trim().substring(0, 50) + "…";
//  $('.side .video-title a').text(truncated);
//}


$('.txt-video').trunk8({
  fill: '&hellip; <a id="read-more" href="#">read more</a>'
});

$(document).on('click', '#read-more', function (event) {
  $(this).parent().trunk8('revert').append(' <a id="read-less" href="#">read less</a>');
  return false;
});

$(document).live('click', '#read-less', function (event) {
  $(this).parent().trunk8();
  return false;
});