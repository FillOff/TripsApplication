import { getJwtToken } from "./jwtProvider";

export async function login(email, password) {
    const data = {
        email: email,
        password: password
    }

    const response = await fetch('http://localhost:8080/api/Auth/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    });

    return await response.text();
}

export async function register(name, email, password) {
    const data = {
        name: name,
        email: email,
        password: password
    }

    await fetch('http://localhost:8080/api/Auth/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data),
    });
}

export async function check() {
    const jwtToken = getJwtToken();

    const response = await fetch('http://localhost:8080/api/auth/me', {
        method: "GET",
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        }
    });

    return response;
}