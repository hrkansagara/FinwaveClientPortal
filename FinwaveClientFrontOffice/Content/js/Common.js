
function RedirectToUrl(url) {
    isRedirectToUrl = true;
    window.location.href = url;
}

function Notify(IsError, strMessage, Container) {

    //if IsError = true then show success message 
    //if IsError = false then show error message 

    (strMessage != "") ? strMessage : "error";
    var strClass = (IsError) ? "alert-success" : "alert-danger"
    var strHtml = "<div class='notifyoverlay divnotify'><div class='alert alerttop " + strClass + " alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert'  aria-label='Close' onclick='CloseNotify()'><span aria-hidden='true'>&times;</span></button><span>" + strMessage + "</span></div></div>"

    if (!Container) {
        $('body').find('.divnotify').remove();
        $('body').append(strHtml);
        $(document).find('.close').trigger('focus');
    } else {
        $(Container).find('.divnotify').remove();
        $(Container).html(strHtml);
        $(document).find('.close').trigger('focus');
    }

    if (IsError) {
        setTimeout(function () {
            $('.divnotify').slideUp('slow').remove();
        }, 1500);
    }
}

function CloseNotify() {
    $('body').find('.divnotify').remove();
}