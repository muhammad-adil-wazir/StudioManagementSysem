jQuery.expr[':'].contains = function (a, i, m) {
    return jQuery(a).text().toUpperCase()
        .indexOf(m[3].toUpperCase()) >= 0;
};
$(document).ready(function (e) {
    $('.loading').hide();
    showNotification();
    $('textarea').css('max-width', $('textarea').css('width'));
    $('textarea').css('max-height', $('textarea').css('height'));
    if ($('#hdnEnquiryChart').length > 0) {
        var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var _projectChart = JSON.parse($('#hdnProjectChart').val());
        var _projectMonthNumbers = _projectChart.map(a => a.Month);
        var _projectCounts = _projectChart.map(a => a.Count);
        var _projectMonths = new Array();
        for (var i = 0; i < _projectMonthNumbers.length; i++) {
            _projectMonths.push(MONTHS[_projectMonthNumbers[i] - 1]);
        }
        var color = Chart.helpers.color;
        var barChartData = {
            labels: _projectMonths,
            datasets: [
            //    {
			//	label: 'Dataset 1',
			//	backgroundColor: '#8080809e',
			//	borderColor: 'gray',
			//	borderWidth: 1,
			//	data: [
			//		22,45,78,95,125
			//	]
			//}
            //,
            {
                label: 'Total Project',
                backgroundColor: '#1e88e591',
                borderColor: '#1e88e5',
                borderWidth: 1,
                data: _projectCounts

            }
            ]
        };
        var _enquiryChart = JSON.parse($('#hdnEnquiryChart').val());
        var _enquiryMonthNumbers = _enquiryChart.map(a => a.Month);
        var _enquiryCounts = _enquiryChart.map(a => a.Count);
        var _enquiryMonths = new Array();
        for (var i = 0; i < _enquiryMonthNumbers.length; i++) {
            _enquiryMonths.push(MONTHS[_enquiryMonthNumbers[i] - 1]);
        }
        var barChartData2 = {
            labels: _enquiryMonths,
            datasets: [{
                label: 'Total Enquiries',
                backgroundColor: '#1e88e591',
                borderColor: '#1e88e5',
                borderWidth: 1,
                data: _enquiryCounts
            }
            //, {
			//	label: 'Dataset 2',
			//	backgroundColor: 'blue',
			//	borderColor: 'blue',
			//	borderWidth: 1,
			//	data: [
			//		20,30,45,85,114
			//	]
            //}
            ]

        };

        var ctx = document.getElementById('canvas').getContext('2d');
        window.myBar = new Chart(ctx, {
            type: 'bar',
            data: barChartData,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: ''
                }
            }
        });

        var ctx2 = document.getElementById('chart-2').getContext('2d');
        window.myline = new Chart(ctx2, {
            type: 'line',
            data: barChartData2,
            options: {
                responsive: true,
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: ''
                }
            }
        });
    }
    if ($('#frmInterface #drpRole') != undefined) {
        if (window.location.href.indexOf('RoleID') == -1) {
            $('#RoleName').text($('#drpRole li:eq(1)').text());
        }
        else {
            var _roleID = window.location.href.split('=')[1];
            $('#hdnRoleID').val(_roleID);
            $('#RoleName').text($('#drpRole li[data-id=' + _roleID + ']').text());
        }

    }

    // initialize table
    $('table:not(.non-datatable)').DataTable({ "order": [[1, "desc"], [2, "desc"]] });

    $('form *:required').on('blur', function () {
        var _elm = $(this);
        if ($.trim(_elm.val()) != undefined && $.trim(_elm.val()) != '') {
            _elm.parents('.input-group').removeClass('border-red');
        }
    });
    $('input[type="checkbox"]').on('click', function () {
        var _chk = $(this);
        if (_chk.is(':checked')) {
            _chk.parents('.row').find('input[id*="Cost"]').removeClass('hidden');
        }
        else {
            _chk.parents('.row').find('input[id*="Cost"]').addClass('hidden');
        }
    });
    $('#tblUserAccess tbody').on('click', 'tr .checkbox-container', function () {
        var _checkbox = $(this).find('input[type="checkbox"]');
        var _interfaceId = _checkbox.parents('tr').find('td:first').data('interfaceid');
        if ($(this).hasClass('checked') == false) {
            $scope.userAccessDetail.push({
                'UserRoleID': $scope.userAccess.UserRoleID,
                'InterfaceID': _interfaceId,
                'EventAccess': _checkbox.val()
            });
            $(this).addClass('checked');
        }
        else {
            $(this).removeClass('checked');
            removeUserAccess(_interfaceId);
        }
    });
    $('#btnRoleAccessCreate').on('click', function () {
        var _roleAccess = new Array();
        $('#tblRoleAccess tbody tr').each(function () {
            var _tr = $(this);
            var _interfaceID = _tr.find('#InterfaceID').text();
            var _roleID = $('#hdnRoleID').val();
            if (_tr.find('#AllowAdd input[type=checkbox]').is(':checked')) {
                _roleAccess.push({
                    'EventAccessID': $('#AllowAddEventID').val(),
                    'InterfaceID': _interfaceID,
                    'RoleID': _roleID
                });
            }
            if (_tr.find('#AllowEdit input[type=checkbox]').is(':checked')) {
                _roleAccess.push({
                    'EventAccessID': $('#AllowEditEventID').val(),
                    'InterfaceID': _interfaceID,
                    'RoleID': _roleID
                });
            }
            if (_tr.find('#AllowDelete input[type=checkbox]').is(':checked')) {
                _roleAccess.push({
                    'EventAccessID': $('#AllowDeleteEventID').val(),
                    'InterfaceID': _interfaceID,
                    'RoleID': _roleID
                });
            }
            if (_tr.find('#AllowView input[type=checkbox]').is(':checked')) {
                _roleAccess.push({
                    'EventAccessID': $('#AllowViewEventID').val(),
                    'InterfaceID': _interfaceID,
                    'RoleID': _roleID
                });
            }
            if (_tr.find('#AllowReport input[type=checkbox]').is(':checked')) {
                _roleAccess.push({
                    'EventAccessID': $('#AllowReportEventID').val(),
                    'InterfaceID': _interfaceID,
                    'RoleID': _roleID
                });
            }
        });
        if (_service.POST('../user/RoleAccessCreate', { 'roleAccessDetail': _roleAccess }, 'JSON', 'Role Access Updated!')) {
            window.location.reload();
        }
    });
    $('.dropdown-menu input[type="text"]').on('keyup', function (e) {
        var _elm = $(this);
        filter = _elm.val();
        var _ul = _elm.parents('ul');
        _ul.find('li:not(:first-child)').addClass('hidden');
        _ul.find('li:contains(' + filter + ')').removeClass('hidden');
    });
});
function showNotification() {
    var _title = localStorage.getItem('title');
    var _type = localStorage.getItem('type');
    var _text = localStorage.getItem('text');
    if (_title != '' && _title != undefined && _type != '' && _type != undefined && _text != '' && _text != undefined) {
        _utility.showNotification(_title, _type, _text);
        $('form .btnClear').click();
    }
    localStorage.removeItem('title');
    localStorage.removeItem('type');
    localStorage.removeItem('text');
}
function create(entity, url, isNameExist,isReload) {
    if (_utility.validateForm('frm' + entity)) {
        var data = _utility.getFormParameters('frm' + entity);
        var _url = '../' + entity + '/Create';
        if (url != undefined && url != '') {
            _url = '../' + url;
        }
        if (isNameExist != '' && isNameExist) {
            var dataa = { 'Entity': entity, 'Name': data[entity + 'Name'] };
            //var dataa = { 'Entity': entity, 'Name': nameExist.data('name'), 'PropertyID': nameExist.data('propertyID'), 'ProertyName': nameExist.data('propertyname'), 'ID': nameExist.data('id') }
            if (_service.GET('../Common/IsNameExists', dataa, 'JSON')) {
                _utility.showNotification('Warning', 'warning', 'Same Name Record Already Exists!');
            }
            else {
                load();
            }
        }
        else {
            load();
        }
        function load() {
            if (_service.POST(_url, data, 'JSON')) {
                if(isReload == undefined)
                    window.location.reload();
            }
        }
    }
    else {
        _utility.showNotification('Warning', 'warning', 'Validation Failed!');
    }
    
}
function edit(entity, elm) {
    $('div.dropdown').each(function (e) {
        $(this).find('button > span:first').text($(this).find('ul').attr('placeholdertext'));
    });
    //$('#tbl' + entity +' tbody tr').find.index()
    var index = $(elm).parents('tr').index();
    $('#tbl' + entity + ' tbody tr:eq(' + index + ') td').each(function () {
        var _td = $(this);
        if (_td.attr('id') != '' && _td.attr('id') != undefined) {
            var _elm = $('#frm' + entity + ' [name=' + _td.attr('id') + ']');
            if (_td.attr('id').indexOf('img') > -1) {
                //_elm.siblings('input[type="file"]').val(_td.text());
                _elm.attr('src', _td.text());
            }
                //else if (_elm.is('select')) {
                //    _elm.val(_td.text());
                //    //_elm.selectpicker('refresh');
                //}
            else if (_elm.parent().is('button') && _td.text() == '') {

            }
            else if (_elm.is('select')) {
                _elm.val(_td.text());
            }
            else {
                _elm.text(_td.text());
                _elm.val(_td.text());
            }
        }
    });
    $('#btnEdit' + entity).removeClass('hidden');
    $('#btnCreate' + entity).addClass('hidden');
    var body = $("html, body");
    body.stop().animate({ scrollTop: 0 }, 500, 'swing', function () {
    });
}
function update(entity, url, isNameExist) {
    if (_utility.validateForm('frm' + entity)) {
        var _url = '../' + entity + '/Edit';
        if (url != undefined && url != '') {
            _url = '../' + url;
        }
        var data = _utility.getFormParameters('frm' + entity);
        if (isNameExist) {
            var dataa = { 'Entity': entity, 'Name': data[entity + 'Name'], 'ID': data[entity + 'ID'] };
            //var dataa = { 'Entity': entity, 'Name': nameExist.data('name'), 'PropertyID': nameExist.data('propertyID'), 'ProertyName': nameExist.data('propertyname'), 'ID': nameExist.data('id') }
            if (_service.GET('../Common/IsNameExists', dataa, 'JSON')) {
                _utility.showNotification('Warning', 'warning', 'Same Name Record Already Exists!');
            }
            else {
                load();
                //if (_service.POST(_url, data, 'JSON')) {
                //    $('#btnEdit' + entity).addClass('hidden');
                //    clearForm(entity);
                //}
            }
        }
        else {
            load();
        }
        function load() {
            if (_service.POST(_url, data, 'JSON')) {
                var _isReload = true;
                if (window.location.href.toLowerCase().indexOf('project/detail') > -1) {
                    window.location.href = "../Project/AllProjects";
                }
                else if (window.location.href.toLowerCase().indexOf('enquiry/detail') > -1) {
                    window.location.href = "../Enquiry/AllEnquiries";
                }
                else{
                    window.location.reload();
                }
            }
        }
    }
    else {
        _utility.showNotification('Warning', 'warning', 'Validation Failed!');
    }
};

function deleteDialog(entity, url, elementID, elementName,table,id) {
    $('#mdlDelete #txtUrl').val(url);
    $('#mdlDelete #txtElementName').val(elementName);
    $('#mdlDelete #txtElementID').val(elementID);
    $('#mdlDelete #txtEntity').val(entity);
    $('#mdlDelete #txtTable').val(table);
    $('#mdlDelete #txtID').val(id);
    $('#mdlDelete .modal-title').text('Delete ' + entity);
    $('#mdlDelete .modal-body p').text('Are you sure you want to delete ' + elementName);
    $('#mdlDelete').modal('show');
}

function confirmDelete() {
    var _url = $('#mdlDelete #txtUrl').val();
    var _elementName = $('#mdlDelete #txtElementName').val();
    var _elementID = $('#mdlDelete #txtElementID').val();
    var _entity = $('#mdlDelete #txtEntity').val();
    var _table = $('#mdlDelete #txtTable').val();
    var _id = $('#mdlDelete #txtID').val();
    if (_elementID != '' && _elementID != undefined) {
        if (_url == undefined || _url == '') {
            _url = '../' + _entity + '/Delete';
        }
        if (_service.POST(_url, { id: _elementID }, 'JSON', 'Record Successfuly Deleted!')) {
            var _isReload = true;
            if (window.location.href.toLowerCase().indexOf('project') > -1) {
                if (_entity == 'Job' || _entity == 'Device' || _entity == 'Employee') {
                    _isReload = false;
                    showNotification();
                }
            }
            else if (window.location.href.toLowerCase().indexOf('enquiry') > -1) {
                if (_entity == 'Skill' || _entity == 'Device' || _entity == 'Employee') {
                    _isReload = false;
                    showNotification();
                }
            }
            if (_isReload) {
                window.location.reload();
            }
            $('#'+ _table +' tbody tr[data-id='+ _id +']').remove();
            //$('#mdlDelete').modal('hide');
            //clearForm(_entity);
        }
    }
    else {
        _utility.showNotification('Error', 'error', 'Please select Element!');
    }
}

function clearForm(entity) {
    $('#btnEdit' + entity).addClass('hidden');
    $('#btnCreate' + entity).removeClass('hidden');
    if ($('[id^=drp]').length > 0) {
        $('[id^=drp]:not(.multiple)').each(function () {
            var _elm = $(this);
            var _id = _elm.attr('id');
            $('#' + _id.replace('drp', '') + 'Name').text(_elm.attr('placeholdertext'));
        });
    }
    _utility.clearFormParameters('frm' + entity);
}
function clearTags() {
    $('.tags li').remove();
}
function toggleItem(elm, entity, obj, id, name, event) {
    event.stopPropagation();
    var _propertyID = entity + 'ID';
    var _array = new Array();
    if ($('#' + elm).val() != '' && $('#' + elm).val() != 'null') {
        _array = JSON.parse($('#' + elm).val());
    }
    if ($(obj).find('input[type="checkbox"]').is(':checked')) {
        
            removeItemFromList(elm, entity, id, _array);
    }
    else {
       
            //var _enquiryID = 0;
            //if ($('#EnquiryID').val() != undefined) {
            //    _enquiryID = $('#EnquiryID').val();
            //}
            var objct = new Object();
            objct['EnquiryID'] = $('#txtEnquiryID').val();
            objct[_propertyID] = id;
            _array.push(objct);
            //_array.push({ 'EnquiryID': $('#EnquiryID').val(), _propertyID: id });
            $('#' + elm).val(JSON.stringify(_array));
            //$('#lst' + entity).append('<li><span onclick="removeItemFromList("' + elm + '","' + entity + '","' + id + '");">X</span>' + name + '</li>');
            var removeFunction = 'removeItemFromList("' + elm + '","' + entity + '",' + id + ')';
            $('#lst' + entity).append("<li data-id=" + id + "><span onclick='" + removeFunction + "'>X</span>" + name + "</li>");
            $(obj).parent('li').find('input[type="checkbox"]').prop('checked', true);
            //_anchor.find('.checkbox-container').addClass('checked').removeClass('unchecked');

            //var _elm = $.grep(_array, function (element, index) {
            //    return element[property] == obj.val();
            //});
            //if (_elm != undefined) {
            //}
    }

}
//function toggleIsHired(elm) {
//    var _elm = $('#' + elm).find('input[type="checkbox"]');
//    if (_elm.is(':checked')) {
//        _elm.prop('checked',false);
//    }
//    else {
//        _elm.prop('checked', true);
//    }
//}
function removeItemFromList(elm, entity, id, array) {
    var _array = new Array();
    if (array != undefined) {
        _array = array;
    }
    if ($('#' + elm).val() != '') {
        _array = JSON.parse($('#' + elm).val());
    }
    for (var i = 0; i < _array.length; i++) {
        if (_array[i][entity + 'ID'] == id) {
            _array.splice(i, 1);
            $('#' + elm).val(JSON.stringify(_array));
            $('#drp' + entity + ' li[data-id=' + id + ']').find('input[type="checkbox"]').removeAttr('checked');
            $('#lst' + entity + ' li[data-id=' + id + ']').remove();
            break;
        }
    }
}
function setItem(entity, id, name) {
    $('#' + entity + 'Name').text(name);
    $('#hdn' + entity + 'ID').val(id);
    $('#' + entity + 'Name').parents('.input-group').removeClass('border-red');
}
function setGender(gender) {
    $('.gender').removeClass('btn-primary');
    $('.gender').addClass('btn-default');
    $('#lbl' + gender).addClass('btn-primary').removeClass('btn-default');
    $('#hdnGender').val(gender);
}
function showReport() {
    //var _name = window.location.href.split('?')[1].replace('/', '').replace('Report', '');

    var data = _utility.getFormParameters('frmReport');
    var _name = data.ReportName;
    var _startDate = data.StartDate;
    var _endDate = data.EndDate;
    var _contractNumber = data.ContractNumber;
    var _url = '/Report/ShowReport?Name=' + _name + '&StartDate=' + _startDate + '&EndDate=' + _endDate;
    if (_contractNumber != undefined && _contractNumber != '') {
        _url += '&ContractNumber=' + _contractNumber;
    }
    window.open(_url, '_blank');
    //window.open('/Report/ShowReport?Name=' + _name + '&StartDate=' + _startDate + '&EndDate=' + _endDate + '&CompanyID=' + $scope.report.CompanyID +
    // '&CompanyName=' + $scope.selectedCompanyName + '&EmployeeIDs=' + $scope.selectedEmployees, '_blank');
}
function addRow(table, object) {
    var _table = $('#' + table + ' tbody');
    var _tr = '<tr>';
    //$.each(object,function(obj){
    //    _tr += '<td id="' + obj + '"> ' + $('#' +obj).val() + '</td>';
    //});
    for (var key in object) {
        if (object.hasOwnProperty(key)) {
            _tr += '<td id="' + key + '"> ' + object[key] + '</td>';
            //console.log(key + " -> " + p[key]);
        }
    }
    _tr += '</tr>';
    _table.append(_tr);
}
function deleteRow(table, elm) {
    var index = $(elm).parents('tr').index();
    $('#' + table + ' tbody tr:eq(' + index + ')').remove();
    _utility.showNotification('Success', 'success', 'Item Deleted');
}
function checkEmployeeAvailability(entity,startDate,endDate) {
    var valid = true;
    $('#frm' + entity + ' *:required, #frm'+entity+' ul.dropdown-menu').each(function (e) {
        var _elm = $(this);
        var val = $.trim(_elm.val());
        if (_elm.is('ul') && (_elm.hasClass('multiple') == false) && !_elm.hasClass('not-required')) {
            var _hiddenElement = $('#hdn' + _elm.attr('id').replace('drp', '') + 'ID');
            if (_hiddenElement.val() == '' || _hiddenElement.val() == '0' || _hiddenElement.val() == undefined) {
                valid = false;
                _elm.parents('.input-group').addClass('border-red');
            }
        }
        else if ((val == '' || val == undefined || _elm.is(':invalid')) && _elm.is(':not(ul)')) {
            valid = false;
            _elm.parents('.input-group').addClass('border-red');
        }
    });
    if (valid) {
        var _employeeID = $('#hdnEmployeeID').val();
        var _skillID = $('#hdnSkillID').val();
        var _skillName = $('#SkillName').text();
        var _fromDate = $('#txtEmployeeFromDate').val();
        var _toDate = $('#txtEmployeeToDate').val();
        var _employeeName = $('#EmployeeName').text();
        if (_employeeID == '' || _employeeID == '0' || _employeeID == undefined) {
            var _employeeName = $('#txtEmployeeName').val();
            var _companyName = $('#txtCompanyName').val();
        }
        var _ishired = $('#chkIsHiredSkill').prop('checked');
        var _isAvailable = false;
        if (_ishired == false) {
            if (_employeeID == '') {
                _utility.showNotification('Warning', "warning", 'Employee Not Selected!');
            }
            else {
                var data = {
                    'FromDate': _fromDate, 'ToDate': _toDate, 'EmployeeID': _employeeID,
                    'ProjectStartDate': startDate, 'ProjectEndDate': endDate
                };
                var _result = _service.GET('../Project/CheckEmployeeAvailability', data, 'JSON');
                var _msg = '';
                if (_result.isDateAvailable == false) {
                    _msg += "Device isn't available on the selected dates!\n";
                    if (_result.avaiableDates.length > 0) {
                        _msg += "Available Dates are \n";
                        var _availableDates = _result.avaiableDates;
                        for (var i = 0; i < _availableDates.length; i++) {
                            _msg += (i + 1) + ' - ' + _availableDates[i].split('T')[0] + '\n';
                        }
                    }
                    _utility.showNotification('Warning', "warning", _msg);
                }
                _isAvailable = _result.isDateAvailable;
            }
        }
        else {
            _employeeID = 0;
        }
        if(_isAvailable || _ishired) {
            var _tr =  '<tr data-skillid="' + _skillID + '" data-skillname="' + _skillName +
                    '"  data-employeeid="' + _employeeID + '" data-todate="' + _toDate + '" data-id=' + _employeeID +
                     '"  data-ishired="' + _ishired + '" data-hiredcost="' + $('#txtHiredCostSkill').val() +
                     '"  data-companyname="' + $('#txtCompanyName').val() + '" data-employeename="' + $('#txtEmployeeName').val() +
                  '" data-employeename="' + _employeeName + '" data-fromdate="' + _fromDate + '"> ' +
                  '<td><input type="button" class="btn btn-sm btn-danger" value="Delete" ' +
                  'onclick="deleteRow(\'tbl' + entity + '\',this);" /></td>'
                  + '<td class="hidden">' + _skillID + '</td>'
                  + '<td>' + _skillName + '</td>'
                  + '<td class="hidden">' + _employeeID + '</td>'
                  + '<td>' + _employeeName + '</td>'
                  + '<td>' + _fromDate + '</td>'
                  + '<td>' + _toDate + '</td>'
                  + '<td>' + _ishired + '</td>'
                  + '<td>' + $('#txtHiredCostSkill').val() + '</td></tr>';
            }
            $('#tbl'+entity+' tbody:eq(0)').append(_tr);
            $('#txtEmployeeFromDate').val('');
            $('#hdnEmployeeID').val('');
            $('#txtEmployeeToDate').val('');
            $('#txtEmployeeName').val('');
            $('#txtCompanyName').val('');
            $('#chkIsHiredSkill').prop('checked',false);
            $('.dropdown #EmployeeName').text('Select Employee');
            $('#hdnSkillID').val('');
            $('#SkillName').text('Select Skill');
    }
    else {
        _utility.showNotification('Warning', 'warning', 'Validation Failed!');
    }
}
function filterEmployeeBySkillID(skillID) {
    var _employees = new Array();
    var _employeeSkills = new Array();
    //if ($('#hdnEnquiryEmployees').val() != '' && $('#hdnEnquiryEmployees').val() != 'null') {
    //    _employees = JSON.parse($('#hdnEnquiryEmployees').val());
    //}
    if ($('#hdnEmployeeSkills').val() != '' && $('#hdnEmployeeSkills').val() != 'null') {
        _employeeSkills = JSON.parse($('#hdnEmployeeSkills').val());
    }
    //var _employeeIds = _employeeSkills.map(e=>e.EmployeeID);
    var _filteredEmployees = new Array();
    //for (var i = 0; i < _employees.length; i++) {
    $('#drpEmployee li:not(:first)').addClass('hidden');
    $('#drpEmployee li:not(:first-child)').addClass('hidden');
    $('#drpEmployee li').each(function () {
        for (var i = 0; i < _employeeSkills.length; i++) {
            if (_employeeSkills[i].EmployeeID == $(this).data('id') && _employeeSkills[i].SkillID == $('#hdnSkillID').val()) {
                $(this).removeClass('hidden');
            }
        }
        //if (_employeeIds.indexOf($(this).data('id')) > -1) {
        //    $(this).removeClass('hidden');
        //}
    });

    //if (_employeeSkills[i].EmployeeID == _employees[i].EmployeeID) {
    //    _filteredEmployees.push(_employees[i]);
    //    $('#drpEmployee').append('<li data-name="'+_employees[i].EmployeeName+'" data-id="'+_employees[i].EmployeeID+'">'+
    //                                '<a href="javascript:void(0)" onclick="setItem("Employee",'+_employees[i].EmployeeID+',"'+_employees[i].EmployeeName+'", event); event.preventDefault()">'+
    //                                 _employees[i].EmployeeName + ' </a></li>');
    //}
    //}
}
function addSkillOjbect(table) {
    var _trs = $('#' + table + ' tbody tr');
    if (_trs.length > 0) {
        var _enquirySkills = new Array();
        _trs.each(function () {
            var _tr = $(this);
            var _hiredCost = _tr.data('hiredcost');
            if (_hiredCost == '' || _hiredCost == undefined) {
                _hiredCost = 0;
            }
            _enquirySkills.push({
                'SkillID': _tr.data('skillid'),
                'EmployeeID': _tr.data('employeeid'),
                'FromDate': _tr.data('fromdate'),
                'ToDate': _tr.data('todate'),
                'IsHired': _tr.data('ishired'),
                'EmployeeName': _tr.data('employeename'),
                'CompanyName': _tr.data('companyname'),
                'HiredCost': _hiredCost
            });
        });
        $('#hdnEmployeeSkills').val(JSON.stringify(_enquirySkills));
        return true;
    }
    _utility.showNotification('Error', 'error', 'Employee Not Selected!');
    return false;
}
function createDevice() {
    if (_utility.validateForm('frmDevice')) {
        var data = _utility.getFormParameters('frmDevice');
        var dataa = { 'Entity': 'Device', 'Name': data['DeviceName'] };
        //var dataa = { 'Entity': entity, 'Name': nameExist.data('name'), 'PropertyID': nameExist.data('propertyID'), 'ProertyName': nameExist.data('propertyname'), 'ID': nameExist.data('id') }
        if (_service.GET('../Common/IsNameExists', dataa, 'JSON')) {
            _utility.showNotification('Warning', 'warning', 'Same Name Record Already Exists!');
        }
        else {
            var _result = _service.GET('../Enquiry/CreateEnquiryDevice', data, 'JSON');
            if (_result.device) {
                $('#drpDevice li:not(:first)').remove();
                for (var i = 0; i < _result.device.length; i++) {
                    $('#drpDevice').append(
                    '<li data-name="' + _result.device[i].DeviceName + '" data-id="' + _result.device[i].DeviceID + '"' +
                    ' data-quantity="' + _result.device[i].Quantity + '" >'
                        + '<a href="javascript:void(0)" onclick="setItem(\'Device\',' + _result.device[i].DeviceID + ',\'' + _result.device[i].DeviceName + '\');">'
                            + _result.device[i].DeviceName + '</a>' +
                    '</li>');
                }
                _utility.showNotification('Success', 'success', 'Record Successfully saved!');
                $('#mdlCreateDevice').modal('hide');
                $('#DeviceName').text(data['DeviceName']);
                $('#hdnDeviceID').val(_result.deviceid);
            }
        }
    }
}
function createSkill() {
    if (_utility.validateForm('frmSkill')) {
        var data = _utility.getFormParameters('frmSkill');
        var dataa = { 'Entity': 'Skill', 'Name': data['SkillName'] };
        //var dataa = { 'Entity': entity, 'Name': nameExist.data('name'), 'PropertyID': nameExist.data('propertyID'), 'ProertyName': nameExist.data('propertyname'), 'ID': nameExist.data('id') }
        if (_service.GET('../Common/IsNameExists', dataa, 'JSON')) {
            _utility.showNotification('Warning', 'warning', 'Same Name Record Already Exists!');
        }
        else {
            var _result = _service.GET('../Enquiry/CreateEnquirySkill', data, 'JSON');
            if (_result.skill) {
                $('#drpSkill li:not(:first)').remove();
                for (var i = 0; i < _result.skill.length; i++) {
                    $('#drpSkill').append(
                    '<li data-name="' + _result.skill[i].SkillName + '" data-id="' + _result.skill[i].SkillID + '" >'
                        + '<a href="javascript:void(0)" onclick="setItem(\'Skill\',' + _result.skill[i].SkillID + ',\'' + _result.skill[i].SkillName + '\');">'
                            + _result.skill[i].SkillName + '</a>' +
                    '</li>');
                }
                _utility.showNotification('Success', 'success', 'Record Successfully saved!');
                $('#mdlCreateSkill').modal('hide');
                $('#SkillName').text(data['SkillName']);
                $('#hdnSkillID').val(_result.skillid);
                filterEmployeeBySkillID(_result.skillid);
            }
        }
    }
}
function isHiredChange(obj) {
    if ($(obj).is(":checked")) {
        $('#txtEmployeeName').parents('.containr').removeClass('hidden');
        $('#txtCompanyName').parents('.containr').removeClass('hidden');
    }
    else if ($('#txtEmployeeName').hasClass('hidden') == false) {
        $('#txtCompanyName').parents('.containr').addClass('hidden');
        $('#txtEmployeeName').parents('.containr').addClass('hidden');
    }
}
function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    var _day = dt.getDate() < 10 ? '0' + dt.getDate() : dt.getDate();
    var _month = (dt.getMonth() + 1) < 10 ? '0' + (dt.getMonth() + 1) : (dt.getMonth() + 1);
    return _day + '/' + _month + "/" + +dt.getFullYear();
}
//function addDevice() {
//    if (elm.indexOf('Project') > -1) {
//        var _fromDate = $(obj).data('fromdate');
//        var _toDate = $(obj).data('todate');
//        if (_fromDate == '' || _fromDate == undefined) {
//            _fromDate = $('#txtFromDate').val();
//        }
//        if (_toDate == '' || _toDate == undefined) {
//            _toDate = $('#txtToDate').val();
//        }
//        if ((_fromDate < $('#txtFromDate').val() || _fromDate > $('#txtToDate').val()) &&
//            (_toDate < $('#txtFromDate').val() || _toDate > $('#txtToDate').val())) {
//            _utility.showNotification('Warning','warning','Please review the Device availability dates');
//        }
//        var _ishired = $(obj).data('ishired');
//        var _hiredCost = $(obj).data('hiredcost');
//        var _quantity = $(obj).data('quantity');
//        $('#tblProjectDevice tbody').append('<tr>' +
//                '<td><input type="button" class="btn btn-sm btn-danger" value="Delete"'+
//                'onclick="deleteRow(\'tblProjectDevice\',this);removeItemFromList("' + elm + '","' + entity + '",' + id + ')" /></td>' +
//                + '<td id="DeviceID" data-id="'+id+'"></td>'
//                + '<td id="DeviceName" data-name="'+name+'"></td>'
//                + '<td id="FromDate" data-fromdate="'+_quantity+'"></td>'
//                + '<td id="ToDate" data-todate="'+ _toDate +'"></td>'
//                + '<td id="IsHired" data-ishired="'+ _fromDate +'"></td>'
//                + '<td id="HiredCost" data-hiredcost="' + _hiredCost + '"></td>'
//                + '<td id="Quantity" data-quantity="' + _quantity + '"></td>');
//        var objct = new Object();
//        objct['EnquiryID'] = $('#txtEnquiryID').val();
//        objct[_propertyID] = id;
//        _array.push({
//            'EnquiryID': $('#txtEnquiryID').val(), 'DeviceID': id,
//            'FromDate': _fromDate, 'ToDate': _toDate, 'IsHired': _ishired,
//            'HiredCost': _hiredCost, 'Quantity': _quantity
//        });
//        $('#' + elm).val(JSON.stringify(_array));
//    }
//    else {
//}
//function deleteDevice() {

//}
function load(entity, url) {
    $('#tbl' + entity).DataTable({ 'ajax': url });
}

var utility = function () {
    return {
        validateForm: function (formId) {
            var valid = true;
            $('#' + formId + ' *:required, #' + formId + ' ul.dropdown-menu').each(function (e) {
                var _elm = $(this);
                var val = $.trim(_elm.val());
                if (_elm.is('select')) {
                    if (val == '0') {
                        valid = false;
                        _elm.parents('.input-group').addClass('border-red');
                    }
                }
                if (_elm.is('ul') && (_elm.hasClass('multiple') == false)) {
                    var _hiddenElement = $('#hdn' + _elm.attr('id').replace('drp', '') + 'ID');
                    if (_hiddenElement.val() == '' || _hiddenElement.val() == '0' || _hiddenElement.val() == undefined) {
                        valid = false;
                        _elm.parents('.input-group').addClass('border-red');
                    }
                }
                else if ((val == '' || val == undefined || _elm.is(':invalid')) && _elm.is(':not(ul)') && _elm.is(':not(input[type="date"])')) {
                    valid = false;
                    _elm.parents('.input-group').addClass('border-red');
                }
            });
            if (valid == false) {
                var body = $("html, body");
                body.stop().animate({ scrollTop: 0 }, 500, 'swing', function () {
                });
            }
            return valid;
        },
        getFormParameters: function (formId) {
            var object = new Object();
            $('#' + formId + ' input:not(.btn),#' + formId + ' textarea,#' + formId + ' select').each(function (e) {
                var elm = $(this);
                //if (elm.attr('type') == 'file') {
                //    object[elm.attr('name')] = elm[0].files[0];
                //}
                //else {
                object[elm.attr('name')] = elm.val();
                //}
            });
            return object;
        },
        setFormParameters: function (formId, object) {
            $('#' + formId + ' input:not(.btn),#' + formId + ' textarea,#' + formId + ' select').each(function (e) {
                var elm = $(this);
                elm.val(object[elm.attr('name')]);
            });
            return object;
        },
        clearFormParameters: function (formId) {
            $('#' + formId + ' input:not(.btn),#' + formId + ' textarea,#' + formId + ' select').each(function (e) {
                var elm = $(this);
                if (elm.is('select')) {
                    elm.val('0');
                    //elm.selectpicker('refresh');
                }
                else {
                    elm.val('');
                }
            });
        },
        showNotification: function (title, type, text) {
            new PNotify({
                title: title,
                text: text,
                type: type,
                styling: 'bootstrap3'
            });
        },
        imagePreview: function (input, element, path) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#' + element).attr('src', e.target.result);
                    $('#' + path).val(e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        },
        getMonthNameByNumber: function (number) {
            var MONTHS = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
            return MONTHS[number];
        }
    };
}

var service = function () {
    return {
        GET: function (url, data, dataType) {
            var _result;
            $('.loading').show();
            $.ajax({
                type: "GET",
                url: url,
                data: data,
                async: false,
                success: function (response) {
                    if (response.status == 'success') {
                        _result = response.data;
                    }
                },
                error: function (response) {
                    if (response.status == 403) {
                        _utility.showNotification('Warning', 'warning', "You're not Authorized for this action!");
                    }
                    else {
                        _utility.showNotification('Error', 'error', 'Technical Error, Contact Administrator!');
                    }
                },
                complete: function () {
                    $('.loading').hide();
                },
                dataType: dataType
            });
            return _result;
        },
        POST: function (url, data, dataType, successMsg) {
            var _successMsg = 'successfully saved!'
            if (successMsg != '' && successMsg != undefined) {
                _successMsg = successMsg
            }
            var _result = false;
            $('.loading').show();
            setTimeout(200);
            $.ajax({
                type: "POST",
                url: url,
                data: data,
                async: false,
                //contentType: false,
                //processData: false,
                success: function (response) {
                    if (response.status == 'success') {
                        localStorage.setItem('title', 'Success');
                        localStorage.setItem('type', 'success');
                        localStorage.setItem('text', _successMsg);
                        _result = true;
                        //if (response.isReload == undefined) {
                        //    window.location.reload();
                        //}
                        //_utility.showNotification('Success', 'success', _successMsg);
                        //_result = true; 

                    }
                    else {
                        _utility.showNotification('Error', 'error', 'Technical Error, Contact Administrator!');
                        //_utility.showNotification('Error', 'error', 'Technical Error, Contact Administrator!');
                        //localStorage.setItem('title', 'Success');
                        //localStorage.setItem('type', 'success');
                        //localStorage.setItem('text', _successMsg);
                    }
                },
                error: function (response) {
                    if (response.status == 403) {
                        _utility.showNotification('Warning', 'warning', "You're not Authorized for this action!");
                    }
                    else {
                        _utility.showNotification('Error', 'error', 'Technical Error, Contact Administrator!');
                    }

                    //localStorage.setItem('title', 'Error');
                    //localStorage.setItem('type', 'error');
                    //localStorage.setItem('text', _successMsg);
                },
                complete: function(){
                    $('.loading').hide();
                },
                dataType: dataType
            });
            return _result;
        }
    }
}
var _service = new service();
var _utility = new utility();