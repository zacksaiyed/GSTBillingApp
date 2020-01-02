var OwnerAddressArray = [];
var OwnerBankArray = [];
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
    $("#OwnerAddresses_StateId").val("");
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
    var StateId = $("#OwnerAddresses_StateId").val();

    if (Street1 !== "" && Street2 !== "" && StateId !== "" && PostCode !== "" && City !== "") {

        var ownerId = $("#OwnerId").val();

        let AddressDetails = {

            AddressUIId: $("#OwnerAddresses_AddressUIId").val(),
            Id: $("#OwnerAddresses_Id").val(),
            Street1: $("#OwnerAddresses_Street1").val(),
            Street2: $("#OwnerAddresses_Street2").val(),
            City: $("#OwnerAddresses_City").val(),
            PostCode: $("#OwnerAddresses_PostCode").val(),
            StateId: $("#OwnerAddresses_StateId").val(),
            IsCreated: $("#OwnerAddresses_IsCreated").val(),
            IsUpdated: $("#OwnerAddresses_IsUpdated").val()
        };
        OwnerAddressArray.push(AddressDetails);



        $.ajax({
            url: "/Home/_Address",
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

                $("body.modal-open").removeAttr("style");
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();

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
                $("#OwnerAddressTable tbody tr").on('click', GetAddressById);
            }

        });
    }
    else {
        $("#AddressErrorNote").css("display", "block");
    }
}

$("#OwnerAddressTable tbody tr").on('click', GetAddressById);
function GetAddressById() {

    var currentRow = $(this).closest("tr");
    var addressId = currentRow.find("td:eq(0) input").val();
    var addressUIID = currentRow.find("td:eq(1) input").val();


    $.ajax({
        url: "/Home/GetAddressById",
        data: { AddressId: addressId, uiAddresses: OwnerAddressArray, AddressGUID: addressUIID },
        //async: false,
        cache: true,
        //context: document.body,
        method: 'POST',
        dataType: "json",
        beforeSend: function () {

            //$(".preloader").css("display", "block");
        },
        success: function (data) {

            $("#OwnerAddresses_Id").val(data.Id);
            $("#OwnerAddresses_AddressUIId").val(data.AddressUIId);
            $("#OwnerAddresses_Street1").val(data.Street1);
            $("#OwnerAddresses_Street2").val(data.Street2);
            $("#OwnerAddresses_City").val(data.City);
            $("#OwnerAddresses_PostCode").val(data.PostCode);
            $("#OwnerAddresses_StateId").val(data.StateId);
            $("#OwnerAddresses_IsCreated").val("False");
            $("#OwnerAddresses_IsUpdated").val("True");
            $("#AddressDeleteBtn").css("display", "block");
            $("#AddressModal").modal('show');


        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again");

        },

        complete: function () {
            $(".preloader").css("display", "none");

        }

    });
}


function DeleteOwnerAddress() {


    var addressUIId = $("#OwnerAddresses_AddressUIId").val();
    var addressId = $("#OwnerAddresses_Id").val();
    var ownerId = $("#OwnerId").val();

    if (parseInt(addressId) > 0) {

        OwnerAddressArray.splice(OwnerAddressArray.findIndex(e => e.Id === parseInt(addressId)), 1);


        $.ajax({
            url: "/Home/DeleteOwnerAddress",
            data: { AddressId: addressId, OwnerId: ownerId },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {
                $("#AddressModal").modal('hide');
                $(".preloader").css("display", "block");
            },
            success: function (data) {

                $.ajax({
                    url: "/Home/_Address",
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

                        $("body.modal-open").removeAttr("style");
                        $('body').removeClass('modal-open');
                        $('.modal-backdrop').remove();

                        //$('.modal-backdrop').css("display", "none");

                    },
                    error: function (xhr) { // if error occured
                        alert("Error occured.please try again");

                    },

                    complete: function () {
                        $(".preloader").css("display", "none");
                        //Address Function reintialize when change in dom
                    }

                });


            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");
                $('#btnAddressModal').on('click', OpenAddressModal);
                $("#AddAddressBtn").on('click', AddAddressDetails);
                $("#OwnerAddressTable tbody tr").on('click', GetAddressById);

            }

        });

    }


    else {
        OwnerAddressArray.splice(OwnerAddressArray.findIndex(e => e.AddressUIId === addressUIId), 1);

        $.ajax({
            url: "/Home/_Address",
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

                $("body.modal-open").removeAttr("style");
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();

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
                $("#OwnerAddressTable tbody tr").on('click', GetAddressById);

            }

        });


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


$("#AddBankDetailBtn").on('click', AddBankDetails);
function AddBankDetails() {

    var BankName = $("#OwnerBank_BankName").val();
    var Branch = $("#OwnerBank_Branch").val();
    var AccountNumber = $("#OwnerBank_AccountNumber").val();
    var IFSC = $("#OwnerBank_IFSC").val();


    if (BankName !== "" && Branch !== "" && AccountNumber !== "" && IFSC !== "") {

        var ownerId = $("#OwnerId").val();

        let BankDetails = {

            BankUID: $("#OwnerBank_BankUID").val(),
            Id: $("#OwnerBank_Id").val(),
            BankName: $("#OwnerBank_BankName").val(),
            Branch: $("#OwnerBank_Branch").val(),
            AccountNumber: $("#OwnerBank_AccountNumber").val(),
            IFSC: $("#OwnerBank_IFSC").val(),
            IsCreated: $("#OwnerBank_IsCreated").val(),
            IsUpdated: $("#OwnerBank_IsUpdated").val()

        };
        OwnerBankArray.push(BankDetails);

        $.ajax({
            url: "/Home/_BankDetail",
            data: { response: OwnerBankArray, OwnerId: ownerId },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {
                $("#BankModal").modal('hide');

            },
            success: function (data) {

                var targetDiv = $('#BankPartialView');
                targetDiv.empty();
                targetDiv.html(data);

                $("body.modal-open").removeAttr("style");
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();

                //$('.modal-backdrop').css("display", "none");

            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");
                //Address Function reintialize when change in dom
                $("#btnBankModal").on('click', OpenBankModal);
                $("#AddBankDetailBtn").on('click', AddBankDetails);
                $("#OwnerBankDetailsTable tbody tr").on('click', GetBankDetailById);
            }

        });
    }
    else {
        $("#BankErrorNote").css("display", "block");
    }
}


$("#OwnerBankDetailsTable tbody tr").on('click', GetBankDetailById);
function GetBankDetailById() {

    var currentRow = $(this).closest("tr");
    var bankId = currentRow.find("td:eq(0) input").val();
    var bankUIID = currentRow.find("td:eq(1) input").val();


    $.ajax({
        url: "/Home/GetBankDetailById",
        data: { BankId: bankId, uiBanks: OwnerBankArray, BankGUID: bankUIID },
        //async: false,
        cache: true,
        //context: document.body,
        method: 'POST',
        dataType: "json",
        beforeSend: function () {

            //$(".preloader").css("display", "block");
        },
        success: function (data) {


            $("#OwnerBank_BankUID").val(data.BankUID);
            $("#OwnerBank_Id").val(data.Id);
            $("#OwnerBank_BankName").val(data.BankName);
            $("#OwnerBank_Branch").val(data.Branch);
            $("#OwnerBank_AccountNumber").val(data.AccountNumber);
            $("#OwnerBank_IFSC").val(data.IFSC);
            $("#OwnerBank_IsCreated").val("False");
            $("#OwnerBank_IsUpdated").val("True");
            $("#BankDeleteBtn").css("display", "block");
            $("#BankModal").modal('show');


        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again");

        },

        complete: function () {
            $(".preloader").css("display", "none");

        }

    });
}

function DeleteOwnerBankDetail() {


    var bankUIId = $("#OwnerBank_BankUID").val();
    var bankId = $("#OwnerBank_Id").val();
    var ownerId = $("#OwnerId").val();

    if (parseInt(bankId) > 0) {

        OwnerBankArray.splice(OwnerBankArray.findIndex(e => e.Id === parseInt(bankId)), 1);


        $.ajax({
            url: "/Home/DeleteBankDetail",
            data: { BankId: bankId, OwnerId: ownerId },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {
                $("#BankModal").modal('hide');
                $(".preloader").css("display", "block");
            },
            success: function (data) {

                $.ajax({
                    url: "/Home/_BankDetail",
                    data: { response: OwnerBankArray, OwnerId: ownerId },
                    //async: false,
                    cache: true,
                    //context: document.body,
                    method: 'POST',
                    beforeSend: function () {
                        $("#BankModal").modal('hide');

                    },
                    success: function (data) {

                        var targetDiv = $('#BankPartialView');
                        targetDiv.empty();
                        targetDiv.html(data);

                        $("body.modal-open").removeAttr("style");
                        $('body').removeClass('modal-open');
                        $('.modal-backdrop').remove();

                        //$('.modal-backdrop').css("display", "none");

                    },
                    error: function (xhr) { // if error occured
                        alert("Error occured.please try again");

                    },

                    complete: function () {
                        $(".preloader").css("display", "none");
                        //Address Function reintialize when change in dom


                    }

                });


            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");
                $("#btnBankModal").on('click', OpenBankModal);
                $("#AddBankDetailBtn").on('click', AddBankDetails);
                $("#OwnerBankDetailsTable tbody tr").on('click', GetBankDetailById);
            }

        });

    }


    else {

        OwnerBankArray.splice(OwnerBankArray.findIndex(e => e.BankUID === bankUIId), 1);

        $.ajax({
            url: "/Home/_BankDetail",
            data: { response: OwnerBankArray, OwnerId: ownerId },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {
                $("#BankModal").modal('hide');

            },
            success: function (data) {

                var targetDiv = $('#BankPartialView');
                targetDiv.empty();
                targetDiv.html(data);

                $("body.modal-open").removeAttr("style");
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();

                //$('.modal-backdrop').css("display", "none");

            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");
                //Address Function reintialize when change in dom
                $("#btnBankModal").on('click', OpenBankModal);
                $("#AddBankDetailBtn").on('click', AddBankDetails);
                $("#OwnerBankDetailsTable tbody tr").on('click', GetBankDetailById);

            }

        });


    }

}

//=============Create Owner=================//
$("#PerformActionBtn").on('click', AddOwner);
function AddOwner() {

    var SaveChangesForm = $("#ManageOwner");

    if (SaveChangesForm.valid()) {

        let AddressViewModel = {
            AddressList: OwnerAddressArray
        };

        let BankDetailViewModel = {
            OwnerBankList: OwnerBankArray
        };


        let ManageOwnerViewModel = {
            OwnerId: $("#OwnerId").val(),
            OwnerName: $("#OwnerName").val(),
            GSTNumber: $("#GSTNumber").val(),
            ContactNumber: $("#ContactNumber").val(),
            Juridication: $("#Juridication").val(),
            BusiniessType: $("#BusiniessType").val(),
            OwnerAddresses: AddressViewModel,
            OwnerBank: BankDetailViewModel

        };

        $.ajax({
            url: "/Home/CreateUpdateOwner",
            data: { model: ManageOwnerViewModel },
            //async: false,
            cache: true,
            //context: document.body,
            method: 'POST',
            beforeSend: function () {

                $(".preloader").css("display", "block");
            },
            success: function (data) {

                if (data==="True") {

                    var url = "/Home/Index";
                    window.open(url, "_self");

                }
                else {
                    alert('Something went wrong , please try again');
                }


            },
            error: function (xhr) { // if error occured
                alert("Error occured.please try again");

            },

            complete: function () {
                $(".preloader").css("display", "none");

            }

        });



    }
}

function DeleteOwner(ownerId) {
    
    $.ajax({
        url: "/Home/DeleteOwner",
        data: { OwnerId: ownerId},
        //async: false,
        cache: true,
        //context: document.body,
        method: 'POST',
        beforeSend: function () {
          
            $(".preloader").css("display", "block");
        },
        success: function (data) {

            if (data === "True") {


                var url = "/Home/Index";
                window.open(url, "_self");

            } else {

                alert("Somethin went wrong");
            }

        },
        error: function (xhr) { // if error occured
            alert("Error occured.please try again");

        },

        complete: function () {
            $(".preloader").css("display", "none");
            $("#btnBankModal").on('click', OpenBankModal);
            $("#AddBankDetailBtn").on('click', AddBankDetails);
            $("#OwnerBankDetailsTable tbody tr").on('click', GetBankDetailById);
        }

    });


}