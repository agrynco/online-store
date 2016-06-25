function initTinyMCE(selector)
{
    tinyMCE.init(
    {
        selector: selector,
        entity_encoding: "raw",
        plugins: [
            "autoresize",
            "advlist autolink lists link image imagetools charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste code",
            "textcolor"
        ],
        toolbar:
            'insertfile undo redo | styleselect | forecolor backcolor | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
        autoresize_bottom_margin: 0,
        convert_urls: false
        //language: 'uk_UA'
    });
}