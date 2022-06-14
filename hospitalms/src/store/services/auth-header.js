export default function authHeader() {
  debugger;
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
      return { Authorization: 'bearer ' + user };
    } else {
      return {};
    }
  }
  