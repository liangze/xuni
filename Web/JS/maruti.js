
$(document).ready(function(){

	
	
	// === Sidebar navigation === //
	$('.submenu > a').click(function(e)
	{
		e.preventDefault();
		var submenus = $('#sidebar li.submenu ul');
		var submenus_parents = $('#sidebar li.submenu');
		var submenu = $(this).siblings('ul');
		var li = $(this).parents('li');
		if(li.hasClass('open'))
		{
			if(($(window).width() > 768) || ($(window).width() < 479)) {
				submenu.slideUp('normal',function(){
					submenu.attr("style","");
				});
			} else {
				submenu.fadeOut(250);
			}
			li.removeClass('open');
		} else 
		{
			if(($(window).width() > 768) || ($(window).width() < 479)) {
				submenus.slideUp();			
				submenu.slideDown();
			} else {
				submenus.fadeOut(250);			
				submenu.fadeIn(250);
			}
			submenus_parents.removeClass('open');		
			li.addClass('open');	
		}
	}).hover(function(){
		clearTimeout(this.timers);
	},function(e){
		e.preventDefault();
		var submenu = $(this).siblings('ul');
		var li = $(this).parents('li');
		this.timers = setTimeout(function(){
			if(($(window).width() > 768) || ($(window).width() < 479)) {
				submenu.slideUp('normal',function(){
					submenu.attr("style","");
				});
			} else {
				submenu.fadeOut(250,function(){
					submenu.attr("style","");
				});
			}
			li.removeClass('open');
		},500);
	});
	
	$('.submenu > ul').hover(function(){
		clearTimeout(this.timers);
		var submenu = $(this);
		var li = $(this).parents('li');
		if(($(window).width() > 768) || ($(window).width() < 479)) {
			submenu.stop().slideDown();
		} else {
			submenu.stop().fadeIn(250);
		}
	},function(e){
		e.preventDefault();
		var submenu = $(this);
		var li = $(this).parents('li');
		timers = setTimeout(function(){
			if(($(window).width() > 768) || ($(window).width() < 479)) {
				submenu.slideUp('normal',function(){
					submenu.attr("style","");
				});
			} else {
				submenu.fadeOut(250,function(){
					submenu.attr("style","");
				});
			}
			li.removeClass('open');
		},150);
	});
	
	var ul = $('#sidebar > ul');
	
	$('#sidebar > a').click(function(e)
	{
		e.preventDefault();
		var sidebar = $('#sidebar');
		if(sidebar.hasClass('open'))
		{
			sidebar.removeClass('open');
			ul.slideUp(250);
		} else 
		{
			sidebar.addClass('open');
			ul.slideDown(250);
		}
	});
	
	// === Resize window related === //
	$(window).resize(function()
	{
		if($(window).width() > 479)
		{
			ul.css({'display':'block'});	
			$('#content-header .btn-group').css({width:'auto'});		
		}
		if($(window).width() < 479)
		{
			ul.css({'display':'none'});
		}
		if($(window).width() > 768)
		{
			$('#user-nav > ul').css({width:'auto',margin:'0'});
            $('#content-header .btn-group').css({width:'auto'});
		}
	});
	
	if($(window).width() < 468)
	{
		ul.css({'display':'none'});
	}
	if($(window).width() > 479)
	{
		ul.css({'display':'block'});
	}
	
	$('input[type=checkbox],input[type=radio]').uniform();
	$('.datepicker').datepicker();
});

