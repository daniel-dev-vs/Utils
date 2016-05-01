// animando scroll da página -- COMEÇO
$(function() {
  $('a').bind('click',function(event){
    var $anchor = $(this);

    $('html, body').stop().animate({scrollTop: $($anchor.attr('href')).offset().top}, 1000,'linear');

      // Outras Animações
      // linear, swing, jswing, easeInQuad, easeInCubic, easeInQuart, easeInQuint, easeInSine, easeInExpo, easeInCirc, easeInElastic, easeInBack, easeInBounce, easeOutQuad, easeOutCubic, easeOutQuart, easeOutQuint, easeOutSine, easeOutExpo, easeOutCirc, easeOutElastic, easeOutBack, easeOutBounce, easeInOutQuad, easeInOutCubic, easeInOutQuart, easeInOutQuint, easeInOutSine, easeInOutExpo, easeInOutCirc, easeInOutElastic, easeInOutBack, easeInOutBounce

    });
});
// animando scroll da página -- FIM




// anima a galeria de doces 
$('.img-doce').mouseenter(function () {
    $(this).css({border: '0 solid #F15971'}).animate({
        borderWidth: 4
    }, 200);
}).mouseleave(function () {
     $(this).animate({
        borderWidth: 0
    }, 500);
});
//anima a galeria de doces  -- FIM


$(document).ready(function() {
  $('.modal-trigger').leanModal();
});