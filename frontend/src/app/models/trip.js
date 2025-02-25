export const tripModel = {
    id: "",
    name: "",
    description: "",
    startDateTime: null,
    endDateTime: null,
    relativeDateTime: 0,
    tripStatus: "",
    route: {
      id: null,
      startPlace: "",
      endPlace: "",
      length: null,
      duration: null,
    },
    comments: [
      {
        id: null,
        content: "",
        userId: null,
      },
    ],
    images: [
      {
        id: null,
        url: "",
        filePath: "",
      },
    ],
};