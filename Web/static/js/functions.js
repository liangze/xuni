// JavaScript Document

$(document).ready(function() {
	var menustate = false;

	$("#tree").fancytree();
	$('.fancybox').fancybox({minWidth:500});
	 $('.bxslider').bxSlider({auto: true});

	$('.footable').footable();
	$(".organisation").orgChart({container: $("#main"), interactive: false, fade: true, speed: 'slow'});
	$(".stdform").validate();
	$('li:has(> ul)').addClass('parent');
	
	$('.sidebarmenu ul ul').hide(); 
	$('.sidebarmenu>ul>li:first a').addClass('active').next('ul').show(); 
	
		//Slide side menu
	 $('.toggle_menu').click(function(){
	   if(menustate){
		   $('.center_content').animate({"left": '0px'});
		   $('.toggle_menu').removeClass('active');
	   }else{
		   $('.center_content').animate({"left": '270px'});
		    $('.toggle_menu').addClass('active');
	   }	   
	   menustate=!menustate	   
	 });
	 
	 $('.toggle_setting').click(function(){							 
		    $( ".right_header" ).slideToggle(250);
			$('.toggle_setting').toggleClass('active');
	  });
	
		 
		//On Click

		$('.sidebarmenu>ul>li a').click(function(){
		 if( $('.sidebarmenu ul ul').is(':hidden') ) {
			 $( ".sidebarmenu ul ul" ).slideUp();
			$( ".sidebarmenu ul li:hover>ul" ).slideToggle(250);	
			$('.sidebarmenu>ul>li>a').removeClass('active');
			 $('.sidebarmenu>ul>li:hover>a').addClass('active');
		 }

		else {
			$( ".sidebarmenu ul li:hover>ul" ).slideUp();	
		 }
	});
		
		$('.collapse_head').click(function(){
		    $(this).next('.collapse_body').slideToggle(250);
			$(this).toggleClass('active');
		});
		
    // Resize content area
	function jqUpdateSize(){
		// Get the dimensions of the viewport
		var height= (($(window).height()));

		
		$( 'body' ).css({
			"min-height": height + "px"
			
		});

		
	
	
	};
	
	
	
	 //Top Menu
	 $('.header ul>li a').click(function(){
		 if($('.header ul li:hover>ul').is(':hidden') ) {
			 $( ".header ul ul" ).slideUp();
			 $( ".header ul li:hover>ul" ).slideToggle(250);	
			 $('.header ul>li').removeClass('active');
			 $('.header ul>li:hover').addClass('active');
		 }

		else {
			$( ".header ul li:hover>ul" ).slideUp();
			$('.header ul>li').removeClass('active');
		 }
	  });
	  

	$(document).ready(jqUpdateSize);    
	$(window).resize(jqUpdateSize);
	
	 $(window).resize(function(){  
		var w = $(window).width();  
		if(w > 768) {  
			$( ".toggle_menu" ).css("display", "none");
			 $('.right_content').css({"left": '270px'});
			 $('.left_content').css({"left": '0px'});
			$('.center_content').css({"left": '0px'});
			$('.right_header').css({"display":"block"});
			$('.ico_body.collapse').removeClass('hide');
			 menustate = true;
			 

			
		}if(w < 768 ) {
		    $( ".toggle_menu" ).css("display", "block");
			$('.right_content').css({"left": '0px'});
			$('.left_content').css({"left": '-270px'});
			$('.center_content').css({"left": '0px'});
			$('.toggle_menu').removeClass('active');
			$('.right_header').css({"display":"none"});
						$('.ico_body.collapse').addClass('hide');

			menustate = false;
		}
	 });
	
	
  
	

	
	
	
	
	
	$("#form").steps({
    bodyTag: "fieldset",
    onStepChanging: function (event, currentIndex, newIndex)
    {
        // Always allow going backward even if the current step contains invalid fields!
        if (currentIndex > newIndex)
        {
            return true;
        }
 
 
        var form = $(this);
 
        // Clean up if user went backward before
        if (currentIndex < newIndex)
        {
            // To remove error styles
            $(".body:eq(" + newIndex + ") label.error", form).remove();
            $(".body:eq(" + newIndex + ") .error", form).removeClass("error");
        }
 
        // Disable validation on fields that are disabled or hidden.
        form.validate().settings.ignore = ":disabled,:hidden";
 
        // Start validation; Prevent going forward if false
        return form.valid();
    },
    onFinishing: function (event, currentIndex)
    {
        var form = $(this);
 
        // Disable validation on fields that are disabled.
        // At this point it's recommended to do an overall check (mean ignoring only disabled fields)
        form.validate().settings.ignore = ":disabled";
 
        // Start validation; Prevent form submission if false
        return form.valid();
    },
    onFinished: function (event, currentIndex)
    {
        var form = $(this);
         
        // Submit form input
        form.submit();
    }
	}).validate({
		errorPlacement: function (error, element)
		{
			element.before(error);
		},
		rules: {
			confirm: {
				equalTo: "#password"
			}
		}
	});
	
						   
});




$(function() {
  $( "#datepicker" ).datepicker({
	showOn: "button",
	buttonImage:_root+"/static/img/calendar.png",
	buttonImageOnly: true
  });
  
  	
  $( "#datefrom" ).datepicker({
		yearRange: "-100:+0",
		changeMonth: true,
		changeYear:true,
	showOn: "button",
	dateFormat : "yy-mm-dd",
	buttonImage: _root+"/static/img/calendar.png",
	buttonImageOnly: true,
	onClose: function( selectedDate ) {
		$( "#to" ).datepicker( "option", "minDate", selectedDate );
	}
   });
	  
   $( "#dateto" ).datepicker({
		yearRange: "-100:+0",
		changeMonth: true,
		changeYear:true,
		dateFormat :"yy-mm-dd",
	  showOn: "button",
	  buttonImage:_root+"/static/img/calendar.png",
	  buttonImageOnly: true,
	  onClose: function( selectedDate ) {
		  $( "#from" ).datepicker( "option", "maxDate", selectedDate );
	  }
  }); 

	 
	 $('.orgChart .hastip').each(function() { // Notice the .each() loop, discussed below
		$(this).qtip({
			position:
		   {
			   my: 'top left',
			   at: 'left bottom' 
		   },
		   content: {
			   title: 'Detail',
			   text: $(this).prev('table'), // Use the "div" element next to this for the content
			   button: true
		   },
		   show: 'click',
		    hide: {
                event: false,
                inactive: 2000
           },
		   style: {
               classes: 'qtip-dark qtip-youtube'
          }
		});
	});
	 
	 

   
   
	
});