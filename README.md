# SettlementBookingTest

## Versions

1. Implemented Function

Validate booking time range.
Throw Exception when conflict booking time.
Add rate limit to API

## How to execute

1. Basic:

```
curl --request POST \
  --url https://localhost:5001/booking \
  --header 'Content-Type: application/json' \
  --data '{
	"bookingTime": "09:00",
	"name": "Keith"
}'
```
