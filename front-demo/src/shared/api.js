import axios from "axios";

const urlBase = "http://localhost:5000/"

const instance = axios.create({
    timeout: 3000,
    headers: { 'Content-Type': 'application/json' },
});

const getQuestions = (data) => {
    return instance.get(`${urlBase}questions`, data).then(result => {
        return result.data;
    }).catch(error => {
        console.log(error)
        throw error.response.data.message
    });
}

const getQuestionsById = (id) => {
    return instance.get(`${urlBase}questions/${id}`).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response.data.message
    });
}

const addQuestions = (data) => {
    return instance.post(`${urlBase}questions`, data).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response.data.message
    });
}

const updateQuestions = (id, data) => {
    return instance.post(`${urlBase}questions/${id}`, data).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response.data.message
    });
}

export {
    getQuestions,
    getQuestionsById,
    addQuestions,
    updateQuestions
}