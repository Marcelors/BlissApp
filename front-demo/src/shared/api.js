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
        throw error.response
    });
}

const getQuestionsById = (id) => {
    return instance.get(`${urlBase}questions/${id}`).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response
    });
}

const addQuestions = (data) => {
    return instance.post(`${urlBase}questions`, data).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response
    });
}

const updateQuestions = (id, data) => {
    return instance.put(`${urlBase}questions/${id}`, data).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response
    });
}

const shareQuestion = (data) => {
    return instance.post(`${urlBase}share`, data).then(result => {
        return result.data;
    }).catch(error => {
        throw error.response
    });
}

const health = (data) => {
    return instance.get(`${urlBase}health`).catch(error => {
        throw error.response
    });
}

export {
    getQuestions,
    getQuestionsById,
    addQuestions,
    updateQuestions,
    shareQuestion,
    health
}