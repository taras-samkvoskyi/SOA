
(function (cr) {
    var AccountChangePasswordViewModel = function (loginEmail) {

        var self = this;

        self.viewModelHelper = new CarRental.viewModelHelper();
        self.passwordModel = new CarRental.AccountChangePasswordModel();
        self.viewMode = ko.observable("changepw"); // changepw, success
        
        self.changePassword = function (model) {
            var errors = ko.validation.group(model);
            self.viewModelHelper.modelIsValid(model.isValid());
            if (errors().length == 0) {
                var unmappedModel = ko.mapping.toJS(model);
                unmappedModel.LoginEmail = loginEmail;
                self.viewModelHelper.apiPost('api/account/changepw', unmappedModel,
                    function (result) {
                        self.viewMode('success');
                    });
            }
            else
                self.viewModelHelper.modelErrors(errors());
        }
    }
    cr.AccountChangePasswordViewModel = AccountChangePasswordViewModel;
}(window.CarRental));
