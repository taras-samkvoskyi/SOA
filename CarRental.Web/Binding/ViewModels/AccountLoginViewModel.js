
(function (cr) {
    var AccountLoginViewModel = function (returnUrl) {

        var self = this;

        self.viewModelHelper = new CarRental.viewModelHelper();
        self.accountModel = new CarRental.AccountLoginModel();

        self.login = function (model) {
            var errors = ko.validation.group(model);
            self.viewModelHelper.modelIsValid(model.isValid());
            if (errors().length == 0) {
                var unmappedModel = ko.mapping.toJS(model);
                self.viewModelHelper.apiPost('api/account/login', unmappedModel,
                    function (result) {
                        if (returnUrl != '' && returnUrl.length > 1)
                            window.location.href = CarRental.rootPath + returnUrl.substring(1);
                        else
                            window.location.href = CarRental.rootPath;
                    });
            }
            else
                self.viewModelHelper.modelErrors(errors());
        }
    }
    cr.AccountLoginViewModel = AccountLoginViewModel;
}(window.CarRental));
