//$(function () {




//    //var ajaxFormSubmit = function () {
//    //    var $form = $(this);
//    //    var options = {
//    //        url: $form.attr("action"),
//    //        type: $form.attr("method"),
//    //       data: $form.serialize()
//    //    };


//    //};


//    //$("form[ data-par-ajax='true']").submit(ajaxFormSubmit);

    

//    var getPage = function () {
        

       
//        var $a = $(this);
        

//        //var options = {
//        //   // url:"http://www.google.com",
//        //    url:$a.attr("href"),
//        //type: "get"
//        //};

//       //alert('seems good');

//        $.ajax({ url: $a.attr("href"), type: "get" }).done(function (data) {
//        var target = $a.parents("div.pagedList").attr("data-par-target");
//        $(target).replaceWith(data);
//       });
//        return false;

        
//    };

    
    
    

//    $(".main.content").on("click", ".pagedList a", getPage());

//});