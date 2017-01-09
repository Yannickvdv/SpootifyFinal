//--------------------------------
// This code compares two fields in a form and submit it
// if they're the same, or not if they're different.
//--------------------------------
function checkPassword(theForm) {
    if (theForm.newInputPassword.value != theForm.newInputPasswordCheck.value) {
        alert('Those emails don\'t match!');
        return false;
    } else {
        return true;
    }
}
