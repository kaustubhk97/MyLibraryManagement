function togglePasswordVisibility() {
    var passwordTextBox = document.getElementById('<%= TextBox2.ClientID %>');
    var toggleIcon = document.getElementById('togglePassword');

    if (passwordTextBox.type === 'password') {
        passwordTextBox.type = 'text';
        toggleIcon.classList.remove('fa-eye-slash');
        toggleIcon.classList.add('fa-eye');
    } else {
        passwordTextBox.type = 'password';
        toggleIcon.classList.remove('fa-eye');
        toggleIcon.classList.add('fa-eye-slash');
    }
}