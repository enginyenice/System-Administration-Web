var settings = {
    "url": "https://ifconfig.me/all.json",
    "method": "GET",
    "timeout": 0,
};


toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function GetIp() {

    $.ajax(settings).done(function (ifconfigResponse) {
        $("#ipAddress").html(`<a href="${ifconfigResponse.ip_addr}">${ifconfigResponse.ip_addr}</a>`)
        AddLog(ifconfigResponse.ip_addr);



    });
}
function AddLog(ip_addr) {

    var createLog = {
        "url": "createlog",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            "IpAddress": ip_addr
        })
    };

    $.ajax(createLog).done(() => {
        toastr["success"](`IP Adresi Kayıt Edildi : ${ip_addr}`);
    });
}


function CreateLog() {
    GetIp();
}


CreateLog();





