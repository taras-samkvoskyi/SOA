
(function (cr) {
    var AccountChangePasswordModel = function () {

        var self = this;

        self.LoginEmail = ko.observable("");
        self.OldPassword = ko.observable("").extend({
            required: { message: "Old Password is required" },
            minLength: { message: "Old Password must be at least 6 characters", params: 6 }
        });
        self.NewPassword = ko.observable("").extend({
            required: { message: "New Password is required" },
            minLength: { message: "New Password must be at least 6 characters", params: 6 }
        });
    }
    cr.AccountChangePasswordModel = AccountChangePasswordModel;
}(window.CarRental));
