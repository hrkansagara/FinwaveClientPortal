
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


function handleCheckClientSuccess(oData) {
    if (oData.Success) {
        $('.clsOtpDetails').show();
        Notify(true, oData.ResponseString);
    }
    else {
        $('.clsOtpDetails').hide();
        Notify(false, oData.ResponseString);
    }
}

function OnSaveUserDetailsBegin() {
    var strMobileOtp = [];
    $(".otp-number-input").each(function () {
        strMobileOtp += $(this).val()
        if (strMobileOtp) {
            $('.clsMobileOtp').val(strMobileOtp);
        }
    });
}

function handleSaveUserDetailsSuccess(oData) {
    if (oData.Success) {
        $('.clsOtpDetails').hide();
        Notify(true, oData.ResponseString);
    }
    else {
        Notify(false, oData.ResponseString);
    }
}


function handleCheckClientSuccess(oData) {
    if (oData.Success) {
        $('.clsOtpDetails').show();
        Notify(true, oData.ResponseString);
    }
    else {
        $('.clsOtpDetails').hide();
        Notify(false, oData.ResponseString);
    }
}

function handleSuccess(oData) {
    if (oData.Success) {
        Notify(true, oData.ResponseString);
    }
    else {
        Notify(false, oData.ResponseString);
    }
}

function handlePasteOTP(e) {
    var clipboardData = e.clipboardData || window.clipboardData || e.originalEvent.clipboardData;
    var pastedData = clipboardData.getData('Text');
    var arrayOfText = pastedData.toString().split('');
    /* for number only */
    if (isNaN(parseInt(pastedData, 10))) {
        e.preventDefault();
        return;
    }
    for (var i = 0; i < arrayOfText.length; i++) {
        if (i >= 0) {
            document.getElementById('otp-number-input-' + (i + 1)).value = arrayOfText[i];
        } else {
            return;
        }
    }
    e.preventDefault();
}

function showNotificationMessage(data) {
    try {
        data = JSON.parse(data);
    }
    catch (error) {
    }
    if (data.ResponseString) {
        Notify(data.Success, data.ResponseString);
    }
    return data.Success;
}
