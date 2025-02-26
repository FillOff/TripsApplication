import { getJwtToken } from "./jwtProvider";

export async function createImage(id, file) {
    const jwtToken = getJwtToken();
    const formData = new FormData();
    formData.append("tripId", id);
    formData.append("file", file);

    const response = await fetch('http://localhost:8080/api/Images', {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        },
        body: formData,
    });

    return await response.text();
}

export async function deleteImage(id) {
    const jwtToken = getJwtToken();

    const response = await fetch(`http://localhost:8080/api/Images/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        },
    });

    return await response.text();
}