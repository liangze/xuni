/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.skin = 'kama'//kama,v2,office2003,皮肤设置 
    config.language = 'zh-cn'; //设置中文环境 
    config.font_names = '宋体;楷体_GB2312;新宋体;黑体;隶书;幼圆;微软雅黑;Arial;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana'; //编辑字体设置 
    config.toolbar =
    [
        ['Source', '-', 'Preview'], ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'], ['Link', 'Unlink', 'Anchor'],
        ['Image', 'Flash', 'Table', 'HorizontalRule', 'SpecialChar', 'Styles',
        'Format', 'Font', 'FontSize'], ['TextColor', 'BGColor'], ['Maximize', '-', 'About']
    ];

    //设置引用路径 
    config.filebrowserBrowseUrl = '/ckeditor/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/ckeditor/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/ckeditor/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '../ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/ckeditor/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; 
};