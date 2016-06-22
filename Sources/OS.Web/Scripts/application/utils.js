function initTinyMCE(selector)
{
    tinyMCE.init(
        {
            selector: selector,
            entity_encoding: "raw",
            plugins: [
                "autoresize",
                "advlist autolink lists link image charmap print preview anchor",
                "searchreplace visualblocks code fullscreen",
                "insertdatetime media table contextmenu paste code"
            ],
            toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            autoresize_bottom_margin: 0,
            entity_encoding: "raw",
            language: 'uk_UA'
        });
}