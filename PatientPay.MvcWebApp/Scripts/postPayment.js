function getByPatientId() {
    const patientId = $('#PatientGivenId').val();
    networkApi("/PostPayment/GetDetailsByPatientId", { patientId }).then(result => {
        handleResponse(result, 'PatientId');
    }).catch(err => {
        showErrorMsg(Constants.NetworkErrorMsg);
    });
}

function getByUsername() {
    const username = $('#Username').val();
    networkApi("/PostPayment/GetDetailsByUsername", { username }).then(result => {
        handleResponse(result, 'Username');
    }).catch(err=>{
        showErrorMsg(Constants.NetworkErrorMsg);
    });
}

function handleResponse(result, type) {
    if (result.ErrorMessages.length > 0) {
        if (type === 'PatientId') $('#Username').val('');
        else if (type === 'Username') $('#PatientGivenId').val('');
        $('#FirstName').val('');
        $('#LastName').val('');
        $('#submitBtn').prop('disabled', true);
        showErrorMsg(result.ErrorMessages[0]);
        return;
    }

    $('#PatientGivenId').val(result.PatientGivenId);
    $('#Username').val(result.Username);
    $('#FirstName').val(result.FirstName);
    $('#LastName').val(result.LastName);
    $('#submitBtn').prop('disabled', false);
    showSuccessMsg(result.SuccessMessage);
}
