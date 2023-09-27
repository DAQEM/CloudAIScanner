import isDev from '$lib/constants';

const url = isDev ? 'http://localhost:5051/' : 'http://account-service/';

export default {
    register: async (username: string, email: string, password: string) => {
        const response = await fetch(`${url}register`, {
            method: 'POST',
            body: JSON.stringify({ username, email, password }),
            headers: { 'Content-Type': 'application/json' },
        });
        return response.json();
    },
    login: async (email: string, password: string) => {
        const response = await fetch(`${url}login`, {
            method: 'POST',
            body: JSON.stringify({ email, password }),
            headers: { 'Content-Type': 'application/json' },
        });
        return response.json();
    },
    logout: async () => {
        const response = await fetch(`${url}logout`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        });
        return response.json();
    },
    verify: async () => {
        const response = await fetch(`${url}verify`, {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        });
        return response.json();
    }
}