function Notify(IsSuccess, strMessage, Container) {
    toastr.options = {
        timeOut: 0,
        extendedTimeOut: 100,
        tapToDismiss: true,
        debug: false,
        fadeOut: 10,
        positionClass: "toast-top-center"
    };
    if (IsSuccess) {
        toastr.success(strMessage);
    } else {
        toastr.error(strMessage);
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
