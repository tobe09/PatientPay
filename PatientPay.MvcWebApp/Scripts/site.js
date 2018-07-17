const Constants = {
    NetworkErrorMsg : "Network error has occured"
}

function showAdminDetails() {
    $('#profileMsg').text('Loading...');
    networkApi("/Home/GetAdminDetails").then(result => {
        $('#profileMsg').text('');
        $('#firstNameProf').text(result.FirstName);
        $('#lastNameProf').text(result.LastName);
        $('#middleNameProf').text(result.MiddleName);
        $('#phoneNoProf').text('0' + result.PhoneNo);
        $('#emailProf').text(result.Email);
        $('#homeAddressProf').text(result.HomeAddress);
    }).catch(err => {
        $('#adminModal').modal('hide');
        showErrorMsg("Error occured in loading administrator profile.");
    });
}

const clearTime = setInterval(() => {
    const date = new Date();
    const currentTime = date.toDateString() + ", " + date.toLocaleTimeString();
    $("#timerSpan").text(currentTime);
}, 1000);

function networkApi(url, data, type = "GET") {
    return new Promise((resolve, reject) => {
        $.ajax({
            dataType: "json",
            url,
            type,
            data,
            success: result=>resolve(result),
            error: err=>reject(err)
        })
    });
}

function showErrorMsg(msg = 'Operation failed', isList = false, msgSpan = $('#msg')) {
    msgSpan.removeClass('text-success');
    msgSpan.addClass('text-danger');
    showMessage(msg, isList, msgSpan)
}

function showSuccessMsg(msg = 'Operation successful', isList = false, msgSpan = $('#msg')) {
    msgSpan.removeClass('text-danger');
    msgSpan.addClass('text-success');
    showMessage(msg, isList, msgSpan)
}

function showMessage(msg, isList, msgSpan) {
    let info;
    if (!isList) {
        info = `<ul> <li>${msg}</li> </ul>`;
    }
    else {
        info = "<ul>"
        for (const val of msg) {
            info += `<li>${val}</li>`;
        }
        info += "</ul>";
    }

    msgSpan.html(info);
}