export const login = async (email, password) => {
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

export const register = async (name, email, password) => {
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