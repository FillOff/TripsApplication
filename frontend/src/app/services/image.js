export const createImage = async (id, file) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];
    const formData = new FormData();
    formData.append("tripId", id);
    formData.append("file", file);

    console.log(formData);
    const response = await fetch('http://localhost:8080/api/Images', {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        },
        body: formData,
    });

    return await response.text();
}

export const deleteImage = async (id) => {
    const jwtToken = document.cookie.split('; ').find(c => c.startsWith('jwt-token=')).split('=')[1];

    const response = await fetch(`http://localhost:8080/api/Images/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${jwtToken}`,
        },
    });

    return await response.text();
}