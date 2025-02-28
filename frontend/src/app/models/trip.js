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
      duration: 0,
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

export const allTripModel = {
  id: "",
  name: "",
  description: "",
  route: {
    id: null,
    startPlace: "",
    endPlace: "",
    length: null,
    duration: 0,
  },
  user: {
    id: null,
    name: ""
  }
};