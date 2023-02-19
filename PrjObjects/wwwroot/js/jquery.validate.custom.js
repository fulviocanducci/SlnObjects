$.validator.setDefaults({
   errorClass: "is-invalid",
   validClass: "is-valid",
   highlight: function (element, errorClass, validClass) {
      $(element).addClass("is-invalid").removeClass("is-valid");
      if (element.id) {
         $(element.form).find("[data-valmsg-for=" + element.id + "]").addClass("invalid-feedback");
      }
   },
   unhighlight: function (element, errorClass, validClass) {
      $(element).addClass("is-valid").removeClass("is-invalid");
      if (element.id) {
         $(element.form).find("[data-valmsg-for=" + element.id + "]").removeClass("invalid-feedback");
      }
   },
});