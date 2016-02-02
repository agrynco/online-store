var debug = true;
jQuery.extend({
    log: function(msg)
    {
        if (debug)
        {
            if (window.console)
            {
                // Firefox & Google Chrome
                console.log(msg);
            } else
            {
                // Other browsers
                $("body").append("<div style=\"width:600px;color:#FFFFFF;background-color:#000000;\">" + msg + "</div>");
            }
            return true;
        }
    }
});
