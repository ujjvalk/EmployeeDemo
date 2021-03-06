function fnvalidation() {
    var ele = $('form')[0];
    var str = '';
    for (var i = 0; i < ele.length; i++) {
        if (ele[i].tagName == 'INPUT') {
            if (ele[i].type == "file") {
                if (ele[i].className.indexOf('required') >= 0) {
                    if (ele[i].defaultValue == "" || ele[i].defaultValue == null || ele[i].defaultValue == undefined) {
                        if (str.length > 0) {
                            str += ',' + ele[i].title;
                        }
                        else {
                            str = ele[i].title;
                        }
                    }
                }
            }
            else if (ele[i].type == "checkbox") {
                if (ele[i].className.indexOf('required') >= 0) {
                    if (ele[i].checked == false) {
                        if (str.length > 0) {
                            str += ',' + ele[i].title;
                        }
                        else {
                            str = ele[i].title;
                        }
                    }
                }
            }
            else if (ele[i].className.indexOf('required') >= 0) {
                if (ele[i].value.trim() == "" || ele[i].value == null || ele[i].value == undefined) {
                    if (str.length > 0) {
                        str += ',' + ele[i].title;
                    }
                    else {
                        str = ele[i].title;
                    }
                }
            }
        }

        else if (ele[i].type == "textarea") {
            if (ele[i].className.indexOf('required') >= 0) {
                var n = ele[i].value;
                if (ele[i].value == "" || ele[i].value == null || ele[i].value == undefined) {
                    if (str.length > 0) {
                        str += ',' + ele[i].title;
                    }
                    else {
                        str = ele[i].title;
                    }
                }
            }
        }
        else if (ele[i].tagName == 'SELECT') {
            if (ele[i].className.indexOf('required') >= 0) {
                if (ele[i].value == "" || ele[i].value == null || ele[i].value == undefined || ele[i].value == 'Select' || ele[i].value == 'select') {
                    if (str.length > 0) {
                        str += ',' + ele[i].title;
                    }
                    else {
                        str = ele[i].title;
                    }
                }
            }
        }

    }
    if (str.length > 0) {
        str += ' is required';
        swal({
            title: "Error",
            text: str,
            timer: 3000,
            type: "error"
        });
        $('#validateBtn').attr('disabled', false);
        return false;
    }
}


function fnReset() {

    var ele = document.getElementsByClassName('formcontrol');
    for (var i = 0; i < ele.length; i++) {

        if (ele[i].tagName == 'INPUT') {
            ele[i].value = '';
            if (ele[i].type == 'file') {
                ele[i].defaultValue = '';
            }
            if (ele[i].type == 'checkbox') {
                ele[i].checked = false;
            }
        }
        else if (ele[i].tagName == 'TEXTAREA') {
            $(ele[i]).val('');
            try {
                for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                }
                CKEDITOR.instances[instance].setData('');
            } catch (e) {

            }

        }
        else if (ele[i].tagName == 'LABEL') {
            $('#' + ele[i].id).empty();
            document.getElementById(ele[i].id).innerHTML = "";
        }

        else if (ele[i].tagName == 'SELECT') {
            document.getElementById(ele[i].id).value = "";
        }

    }
}
function fnSuccess() {
    var msg = document.getElementById('SuccessMessage').value;
    $('#validateBtn').attr('disabled', false);
    if (msg.length > 0 && msg != undefined && msg != " ") {
        swal({
            title: "Success",
            text: msg,
            timer: 3000,
            type: "success"
        });
    }
    else {
        //msg = document.getElementById('Errormessage').value;
        //swal({
        //    title: "Error",
        //    text: msg,
        //    timer: 3000,
        //    type: "error"
        //});
    }

    fnReset();
    fnadddatatable();
    scrolltop();
}

function fnSuccessMenu() {
    var msg = document.getElementById('SuccessMessage').value;
    $('#validateBtn').attr('disabled', false);
    swal({
        title: "Success",
        text: msg,
        timer: 3000,
        type: "success"
    });
    fnReset();    
    fnadddatatable();
    scrolltop();
}
function fnadddatatable() {
    if ($('#example')[0] != undefined) {
        $('#example').DataTable();
    }
}

function scrolltop() {
    $('html, body').animate({ scrollTop: 0 }, 800);
}