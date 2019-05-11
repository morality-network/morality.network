$('.slide a').click(function () {
  $('.slide.active').removeClass('active');
  $(this).closest('.slide').addClass('active');
  return false;
});