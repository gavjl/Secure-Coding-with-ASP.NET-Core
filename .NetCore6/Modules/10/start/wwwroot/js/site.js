$(".popup-open").on("click", function() {
    $(".popup, .popup-body").addClass("active");
});
  
$(".popup-close").on("click", function() {
    $(".popup, .popup-body").removeClass("active");
});