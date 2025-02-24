'use client';
import { useEffect, useRef } from "react";
import L from "leaflet";
import "leaflet/dist/leaflet.css";
import "leaflet-routing-machine/dist/leaflet-routing-machine.css";
import "leaflet-routing-machine";

export default function Map({startCity, endCity}) {
    const mapRef = useRef(null);

    async function geocode(city) {
        const response = await fetch(
            `https://nominatim.openstreetmap.org/search?city=${city}&format=json&addressdetails=1&limit=1`
        );
        const data = await response.json();
        if (data && data[0]) {
            return [data[0].lat, data[0].lon];
        }
        throw new Error("Город не найден");
    }

    async function buildRoute(map, startCity, endCity) {
        try {
            const [startLat, startLon] = await geocode(startCity);
            const [endLat, endLon] = await geocode(endCity);
    
            L.Routing.control({
                waypoints: [
                    L.latLng(startLat, startLon),
                    L.latLng(endLat, endLon)
                ],
                routeWhileDragging: true,
                showAlternatives: false,
                createMarker: () => null
            }).addTo(map);
        } catch (error) {
            alert(error.message);
        }
    }

    useEffect(() => {
        if (mapRef.current) {
            const map = L.map(mapRef.current).setView([53.9045, 27.5615], 6);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(map);

            buildRoute(map, startCity, endCity);
        }
    }, []);

    return (
        <div>
            <div id="map" ref={mapRef} style={{ height: "500px", marginTop: "10px" }} />
        </div>
    );
}