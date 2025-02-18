from flask import Flask, jsonify

app = Flask(__name__)

@app.route('/topics', methods=['GET'])
def get_topics():
    # Hard-coded list of topics
    topics = [
        "Artificial Intelligence",
        "Machine Learning",
        "Data Science",
        "Web Development",
        "Cloud Computing"
    ]
    print("Extracting topics...")
    return jsonify({"topics": topics})

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5002)
