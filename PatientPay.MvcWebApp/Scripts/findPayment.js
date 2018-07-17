//not used
/*function showDetails(patientId) {
    dataApi("/FindPayment/GetPatientHistory", { patientId }).then(result=> {
        $('PatientGivenId').innerText = result.PatientGivenId;
        $('Username').innerText = result.Username;
        $('FirstName').innerText = result.FirstName;
        $('LastName').innerText = result.LastName;
        $('MiddleName').innerText = result.MiddleName;
        $('Email').innerText = result.Email;
        $('PhoneNo').innerText = result.PhoneNo;
        $('PhoneNo2').innerText = result.PhoneNo2;
        $('HomeAddress').innerText = result.HomeAddress;
        $('CreatedDate').innerText = result.CreatedDate;
        $('TotalAmount').innerText = result.TotalAmount;

        if (result.PaymentDetails == 0) return;

        let tableHtml = "<table> <tr> <td>S/N</td> <td>Date Paid</td> <td>Amount Paid</td> </tr>";
        for(const paymentDetail of result.PaymentDetails){
            tableHtml += `<tr> <td>${paymentDetail.Date}</td> <td>${paymentDetail.Amount}</td> </tr>`
        }
        tableHtml += " </table>";

        $('#PaymentTableDiv').innerHTML = tableHtml;
    }).catch(err=> {
        showErrorMsg($('#msg'), "Network error has occured");
    });
}*/
