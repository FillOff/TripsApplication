export function getJwtToken() {
    let jwtToken;

    if (typeof window !== 'undefined' && document.cookie) {
        const cookie = document.cookie.split('; ').find(c => c.startsWith('jwt-token='));
        if (cookie) {
            jwtToken = cookie.split('=')[1];
        }
    }

    return jwtToken;
}