var OwnerAddressArray = [];

$(document).ready(function () {

    $('.device-table').DataTable({

        colReorder: true,
        "bPaginate": true,
        "bFilter": true,

        columnDefs: [
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ]





    });

});


function uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

//=========================Owner Address==================================///

$("#btnAddressModal").on('click', OpenAddressModal);
function OpenAddressModal() {
    var GUID = uuidv4();
    //$("#OwnerAddresses_Id").val("");
    $("#OwnerAddresses_AddressUIId").val(GUID);
    $("#OwnerAddresses_Street1").val("");
    $("#OwnerAddresses_Street2").val("");
    $("#OwnerAddresses_City").val("");
    $("#OwnerAddresses_PostCode").val("");
    $("#OwnerAddresses_State").val("");
    $("#AddressDeleteBtn").css("display", "none");
    $("#AddressErrorNote").css("display", "none");
    $("#AddressModal").modal('show');

}


$("#AddAddressBtn").on('click', AddAddressDetails);
function AddAddressDetails() {

    
    var Street1 = $("#OwnerAddresses_Street1").val();
    var Street2 = $("#OwnerAddresses_Street2").val();
    var City = $("#OwnerAddresses_City").val();
    var PostCode = $("#OwnerAddresses_PostCode").val();
    var State = $("#OwnerAddresses_State").val();
    
    
    

    if ( Street1 !== "" && Street2 !== "" && State !== ""  && PostCode !== "" && City !== "") {

        var ownerId = $("#OwnerId").val();

        let AddressDetails = {

            AddressUIId: $("#OwnerAddresses_AddressUIId").val(),
            Id: $("#OwnerAddresses_Id").val(),
            Street1: $("#OwnerAddresses_Street1").val(),
            Street2: $("#OwnerAddresses_Street2").val(),
            City: $("#OwnerAddresses_City").val(),
            PostCode: $("#OwnerAddresses_PostCode").val(),
            State: $("#OwnerAddresses_State").val(),
            IsCreated: $("#OwnerAddresses_IsCreated").val(),
            IsUpdated: $("#OwnerAddresses_IsUpdated").val()
        };
        OwnerAddressArray.push(AddressDetails);

        var ArrayLength = OwnerAddressArray.length;

        $.ajax({
            url: "/Home/_Addresses",
            data: { response: OwnerAddressArray, OwnerId: ownerId },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {
                $("#AddressModal").modal('hide');
                
            },
            success: function (data) {

                var targetDiv = $('#AddressesPartialView');
                targetDiv.empty();
                targetDiv.html(data);

                //$("body.modal-open").removeAttr("style");
                //$('body').removeClass('modal-open');
                //$('.modal-backdrop').remove();

                //$('.modal-backdrop').css("display", "none");

            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");
                //Address Function reintialize when change in dom
                $('#btnAddressModal').on('click', OpenAddressModal);
                $("#AddAddressBtn").on('click', AddAddressDetails);

            }

        });
    }
    else {
        $("#AddressErrorNote").css("display", "block");
    }
}



//=======================Owner Bank===================================//
$("#btnBankModal").on('click', OpenBankModal);
function OpenBankModal() {
    var GUID = uuidv4();

    //$("#OwnerBank_Id").val("");
    $("#OwnerBank_BankUID").val(GUID);
    $("#OwnerBank_BankName").val("");
    $("#OwnerBank_Branch").val("");
    $("#OwnerBank_AccountNumber").val("");
    $("#OwnerBank_IFSC").val("");
    $("#BankDeleteBtn").css("display", "none");
    $("#BankErrorNote").css("display", "none");
    $("#BankModal").modal('show');

}
